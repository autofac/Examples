using Autofac;
using Autofac.Extras.DynamicProxy;

namespace DynamicProxyExample;

internal static class Program
{
    public static void Main()
    {
        var builder = new ContainerBuilder();

        // The interceptor is an ordinary registration, so it can take
        // dependencies like anything else in the container.
        builder.Register(_ => new CallLogger(Console.Out));

        // Style one: the registration names the interceptor.
        builder.RegisterType<Calculator>()
            .As<ICalculator>()
            .EnableInterfaceInterceptors()
            .InterceptedBy(typeof(CallLogger));

        // Style two: IGreeter carries [Intercept], so the registration only has
        // to opt in to interception at all.
        builder.RegisterType<Greeter>()
            .As<IGreeter>()
            .EnableInterfaceInterceptors();

        using var container = builder.Build();

        Console.WriteLine("Calling ICalculator.Add, intercepted by registration:");
        var sum = container.Resolve<ICalculator>().Add(2, 3);
        Console.WriteLine($"Result: {sum}");

        Console.WriteLine();
        Console.WriteLine("Calling IGreeter.Greet, intercepted by attribute:");
        var greeting = container.Resolve<IGreeter>().Greet("Autofac");
        Console.WriteLine($"Result: {greeting}");
    }
}
