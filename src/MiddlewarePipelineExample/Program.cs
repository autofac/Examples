using Autofac;
using Autofac.Core;
using MiddlewarePipelineExample.Middleware;
using MiddlewarePipelineExample.Services;

namespace MiddlewarePipelineExample;

internal static class Program
{
    /// <summary>
    /// Runs each scenario in turn. They are independent, so they each build their
    /// own container rather than sharing one.
    /// </summary>
    public static void Main()
    {
        AuditEveryRegistration();
        TimeAResolve();
        ShortCircuitWithACache();
        InjectAmbientState();
        RejectRootScopeResolves();
    }

    /// <summary>
    /// Attaches middleware to every registration at once, without naming it on
    /// each one. Autofac issue #1337 asked for exactly this hook.
    /// </summary>
    private static void AuditEveryRegistration()
    {
        Header("Middleware on every registration");

        var activated = new List<string>();
        var builder = new ContainerBuilder();

        builder.ComponentRegistryBuilder.Registered += (sender, args) =>
            args.ComponentRegistration.PipelineBuilding += (sender2, pipeline) =>
                pipeline.Use(new ActivationAuditMiddleware(activated));

        builder.RegisterType<ReportService>().As<IReportService>();
        builder.RegisterType<ScopedResource>().As<IScopedResource>();

        using var container = builder.Build();
        using var scope = container.BeginLifetimeScope();
        scope.Resolve<IReportService>();
        scope.Resolve<IScopedResource>();

        Console.WriteLine($"  activated: {string.Join(", ", activated)}");
        Console.WriteLine("  neither registration mentions the middleware.");
    }

    /// <summary>
    /// Service middleware wraps every resolve of a service, so it can measure what
    /// activation actually costs without the service or its registration knowing.
    /// </summary>
    private static void TimeAResolve()
    {
        Header("Timing a resolve");

        var builder = new ContainerBuilder();
        builder.RegisterType<SlowService>().As<ISlowService>();
        builder.RegisterServiceMiddleware<ISlowService>(new TimingMiddleware(m => Console.WriteLine($"  {m}")));

        using var container = builder.Build();
        using var scope = container.BeginLifetimeScope();
        scope.Resolve<ISlowService>();
    }

    /// <summary>
    /// Setting <c>Instance</c> and returning without calling <c>next</c> ends the
    /// pipeline early, so activation never happens. That is what makes a middleware
    /// cache cheaper than a registration which has to construct something before it
    /// can decide the work was unnecessary.
    /// </summary>
    private static void ShortCircuitWithACache()
    {
        Header("Short-circuiting the pipeline");

        var builder = new ContainerBuilder();
        builder.RegisterType<SlowService>().As<ISlowService>();
        builder.RegisterServiceMiddleware<ISlowService>(new CachingMiddleware(m => Console.WriteLine($"  {m}")));

        using var container = builder.Build();
        for (var i = 0; i < 2; i++)
        {
            using var scope = container.BeginLifetimeScope();
            scope.Resolve<ISlowService>();
        }

        Console.WriteLine("  the second resolve never reached activation.");
    }

    /// <summary>
    /// Supplies a constructor argument no caller passes. Watch which pipeline this
    /// one attaches to: parameter selection belongs to the registration pipeline, so
    /// service middleware is rejected outright.
    /// </summary>
    private static void InjectAmbientState()
    {
        Header("Injecting ambient state");

        var correlationId = "req-001";
        var builder = new ContainerBuilder();

        // Parameter selection is a registration pipeline phase, so this one goes
        // on the registration. Adding it as service middleware throws, because a
        // service pipeline has already finished by the time parameters matter.
        builder.RegisterType<RequestHandler>()
            .As<IRequestHandler>()
            .ConfigurePipeline(pipeline => pipeline.Use(new CorrelationIdMiddleware(() => correlationId)));

        using var container = builder.Build();

        using (var scope = container.BeginLifetimeScope())
        {
            Console.WriteLine($"  {scope.Resolve<IRequestHandler>().Describe()}");
        }

        correlationId = "req-002";
        using (var scope = container.BeginLifetimeScope())
        {
            Console.WriteLine($"  {scope.Resolve<IRequestHandler>().Describe()}");
        }

        Console.WriteLine("  no caller passed the correlation id.");
    }

    /// <summary>
    /// Turns a captured dependency into an immediate, readable failure. Resolving a
    /// per-scope service straight from the root container would otherwise keep it
    /// alive for the life of the application, and the symptom usually shows up a
    /// long way from the cause.
    /// </summary>
    private static void RejectRootScopeResolves()
    {
        Header("Failing fast on a root scope resolve");

        var builder = new ContainerBuilder();
        builder.RegisterType<ScopedResource>().As<IScopedResource>().InstancePerLifetimeScope();
        builder.RegisterServiceMiddleware<IScopedResource>(new RootScopeGuardMiddleware());

        using var container = builder.Build();

        using (var scope = container.BeginLifetimeScope())
        {
            Console.WriteLine($"  from a child scope: {scope.Resolve<IScopedResource>().Use()}");
        }

        try
        {
            container.Resolve<IScopedResource>();
        }
        catch (DependencyResolutionException ex)
        {
            Console.WriteLine($"  from the root scope: {ex.Message.Split(" ---> ")[^1]}");
        }
    }

    /// <summary>
    /// Writes a section title so each scenario's output is easy to tell apart.
    /// </summary>
    private static void Header(string title)
    {
        Console.WriteLine();
        Console.WriteLine(title);
        Console.WriteLine(new string('-', title.Length));
    }
}
