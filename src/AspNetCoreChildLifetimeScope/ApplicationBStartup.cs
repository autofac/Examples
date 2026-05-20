using AspNetCoreChildLifetimeScope.Services;
using Autofac;
using Autofac.Extensions.DependencyInjection;

namespace AspNetCoreChildLifetimeScope;

public class ApplicationBStartup
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

    public void ConfigureContainer(AutofacChildLifetimeScopeConfigurationAdapter configurationAdapter)
    {
        configurationAdapter.Add(
            builder => builder
                .RegisterType<ApplicationBScopedDependency>()
                .AsSelf()
                .InstancePerLifetimeScope());
    }
}
