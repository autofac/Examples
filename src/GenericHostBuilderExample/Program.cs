using System.Threading.Tasks;
using Autofac;
using Autofac.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;

namespace GenericHostBuilderExample
{
    internal class Program
    {
        private static async Task Main() =>
            await new HostBuilder()
                .UseServiceProviderFactory(new AutofacServiceProviderFactory())
                .ConfigureContainer<ContainerBuilder>((context, builder) =>
                {
                    builder.RegisterType<Logger>().As<ILogger>();
                    builder.RegisterType<HostedService>().As<IHostedService>();
                })
                .RunConsoleAsync();
    }
}
