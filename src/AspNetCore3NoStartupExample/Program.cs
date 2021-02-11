using System.Threading.Tasks;
using Autofac;
using Autofac.Extensions.DependencyInjection;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Hosting;
using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.DependencyInjection;

namespace AspNetCore3NoStartupExample
{
    public class Program
    {
        public static async Task Main(string[] args)
        {
            // The example here is exactly the same as AspNetCore3Example, but this
            // shows how you'd use the AutofacServiceProviderFactory and container
            // configuration when you don't have a Startup class. The
            // GenericHostBuilderExample shows how you do this when it's generic
            // hosted services and not ASP.NET Core.
            var host = Host.CreateDefaultBuilder(args)
                .UseServiceProviderFactory(new AutofacServiceProviderFactory())
                .ConfigureWebHostDefaults(webHostBuilder =>
                {
                    webHostBuilder.Configure(app =>
                    {
                        app.UseRouting();
                        app.UseEndpoints(builder => builder.MapControllers());
                    });

                    webHostBuilder.ConfigureServices(services => services.AddControllers());
                })
                .ConfigureContainer<ContainerBuilder>(builder => builder.RegisterModule(new AutofacModule()))
                .Build();

            await host.RunAsync();
        }
    }
}
