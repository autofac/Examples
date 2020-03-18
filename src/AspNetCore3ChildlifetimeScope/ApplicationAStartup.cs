using AspNetCore3ChildlifetimeScope.Services;
using Autofac;
using Autofac.Extensions.DependencyInjection;
using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;

namespace AspNetCore3ChildlifetimeScope
{
    public class ApplicationAStartup
    {
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddControllers();
        }

        public void Configure(IApplicationBuilder app)
        {
            app.UseRouting();

            app.UseEndpoints(builder => builder.MapControllers());
        }

        /// <summary>
        /// This method is called by the <see cref="IHost"/> since we are registering <see cref="AutofacChildLifetimeScopeServiceProviderFactory"/> for Host A.
        /// </summary>
        /// <param name="configurationAdapter">An adapter that can take several registrations for the scope used in Application A.</param>
        public void ConfigureContainer(AutofacChildLifetimeScopeConfigurationAdapter configurationAdapter)
        {
            // You must use an AutofacChildLifetimeScopeConfigurationAdapter
            // here instead of a ContainerBuilder.
            configurationAdapter.Add(
                builder => builder
                    .RegisterType<ApplicationAScopedDependency>()
                    .AsSelf()
                    .InstancePerLifetimeScope()
                );
        }
    }
}