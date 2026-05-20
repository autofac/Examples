using AspNetCoreChildLifetimeScope.Services;
using Autofac;
using Autofac.Extensions.DependencyInjection;

namespace AspNetCoreChildLifetimeScope;

public static class Program
{
    public static async Task Main(string[] args)
    {
        // Build a root container with shared/singleton dependencies.
        var containerBuilder = new ContainerBuilder();
        containerBuilder.RegisterType<SingletonRootDependency>()
            .AsSelf()
            .SingleInstance();

        var container = containerBuilder.Build();

        // Create child lifetime scopes for each application. Each scope
        // can have its own registrations while sharing the root container.
        await using var scopeApplicationA = container.BeginLifetimeScope("ScopeApplicationA", builder =>
            builder.RegisterType<TransientChildScopeDependency>().AsSelf().InstancePerDependency());

        await using var scopeApplicationB = container.BeginLifetimeScope("ScopeApplicationB", builder =>
            builder.RegisterType<TransientChildScopeDependency>().AsSelf().InstancePerDependency());

        using var hostApplicationA = CreateHostForApplicationA(scopeApplicationA, args);
        using var hostApplicationB = CreateHostForApplicationB(scopeApplicationB, args);

        await Task.WhenAll(hostApplicationA.RunAsync(), hostApplicationB.RunAsync());
    }

    private static IHost CreateHostForApplicationA(ILifetimeScope scope, string[] args)
    {
        // Each application uses a separate lifetime scope as the "root"
        // for the application, while sharing the common container for
        // common dependencies.
        return Host.CreateDefaultBuilder(args)
            .UseServiceProviderFactory(new AutofacChildLifetimeScopeServiceProviderFactory(scope))
            .ConfigureWebHostDefaults(builder => builder.UseStartup<ApplicationAStartup>().UseUrls("http://localhost:5000"))
            .Build();
    }

    private static IHost CreateHostForApplicationB(ILifetimeScope scope, string[] args)
    {
        return Host.CreateDefaultBuilder(args)
            .UseServiceProviderFactory(new AutofacChildLifetimeScopeServiceProviderFactory(scope))
            .ConfigureWebHostDefaults(builder => builder.UseStartup<ApplicationBStartup>().UseUrls("http://localhost:5001"))
            .Build();
    }
}
