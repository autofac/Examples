using Autofac;
using Autofac.Pooling;

namespace PoolingExample;

internal static class Program
{
    public static void Main()
    {
        var builder = new ContainerBuilder();
        builder.RegisterType<ExpensiveConnection>()
            .As<IExpensiveConnection>()
            .PooledInstancePerLifetimeScope(new ConnectionPoolPolicy());

        using var container = builder.Build();

        Console.WriteLine("Two scopes one after the other:");
        for (var i = 1; i <= 2; i++)
        {
            using var scope = container.BeginLifetimeScope();
            var connection = scope.Resolve<IExpensiveConnection>();
            connection.Use();
            Console.WriteLine($"  scope {i} got connection {connection.Id}, use count {connection.UseCount}");
        }

        Console.WriteLine();
        Console.WriteLine("Two scopes open at the same time:");
        using (var first = container.BeginLifetimeScope())
        using (var second = container.BeginLifetimeScope())
        {
            Console.WriteLine($"  first scope got connection {first.Resolve<IExpensiveConnection>().Id}");
            Console.WriteLine($"  second scope got connection {second.Resolve<IExpensiveConnection>().Id}");
        }

        Console.WriteLine();
        Console.WriteLine($"Connections constructed in total: {ExpensiveConnection.CreatedCount}");
        Console.WriteLine("Sequential scopes shared one instance; overlapping scopes each needed their own.");
    }
}
