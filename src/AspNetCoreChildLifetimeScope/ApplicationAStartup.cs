using AspNetCoreChildLifetimeScope.Services;
using Autofac;
using Autofac.Extensions.DependencyInjection;

namespace AspNetCoreChildLifetimeScope;

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
    /// When using AutofacChildLifetimeScopeServiceProviderFactory, the
    /// ConfigureContainer method receives an adapter instead of a
    /// ContainerBuilder. The adapter collects registrations that will be
    /// applied to the child lifetime scope for this application.
    /// </summary>
    public void ConfigureContainer(AutofacChildLifetimeScopeConfigurationAdapter configurationAdapter)
    {
        configurationAdapter.Add(
            builder => builder
                .RegisterType<ApplicationAScopedDependency>()
                .AsSelf()
                .InstancePerLifetimeScope());
    }
}
