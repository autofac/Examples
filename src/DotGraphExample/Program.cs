using Autofac;
using Autofac.Diagnostics.DotGraph;

namespace DotGraphExample;

internal static class Program
{
    public static void Main()
    {
        var builder = new ContainerBuilder();
        builder.RegisterType<DataSource>().As<IDataSource>().SingleInstance();
        builder.RegisterType<UppercaseFormatter>().As<IFormatter>().InstancePerLifetimeScope();
        builder.RegisterDecorator<BracketFormatter, IFormatter>();
        builder.RegisterType<ReportGenerator>().As<IReportGenerator>();

        using var container = builder.Build();

        // The tracer raises an event per completed resolve operation, and the
        // trace content is a Graphviz DOT document describing that operation.
        var tracer = new DotDiagnosticTracer();
        var graphs = new List<string>();
        tracer.OperationCompleted += (sender, args) => graphs.Add(args.TraceContent);
        container.SubscribeToDiagnostics(tracer);

        using (var scope = container.BeginLifetimeScope())
        {
            Console.WriteLine($"Report: {scope.Resolve<IReportGenerator>().Generate()}");
        }

        var output = Path.Combine(AppContext.BaseDirectory, "resolve-graph.dot");
        File.WriteAllText(output, string.Join(Environment.NewLine, graphs));

        Console.WriteLine();
        Console.WriteLine($"Captured {graphs.Count} resolve operation(s), written to:");
        Console.WriteLine($"  {output}");
        Console.WriteLine();
        Console.WriteLine("Render it with Graphviz:");
        Console.WriteLine($"  dot -T png -O \"{output}\"");
        Console.WriteLine();
        Console.WriteLine("Tracing is expensive. Turn it on while troubleshooting, not in production.");
    }
}
