using Autofac.Extensions.DependencyInjection;

namespace AspNetCoreExample;

public class Program
{
    public static void Main(string[] args)
    {
        // UseServiceProviderFactory enables the ConfigureContainer method
        // in the Startup class to receive a strongly-typed ContainerBuilder.
        // Autofac automatically calls Populate to move services registered
        // during ConfigureServices into the Autofac container.
        Host.CreateDefaultBuilder(args)
            .UseServiceProviderFactory(new AutofacServiceProviderFactory())
            .ConfigureWebHostDefaults(webBuilder => webBuilder.UseStartup<Startup>())
            .Build()
            .Run();
    }
}
