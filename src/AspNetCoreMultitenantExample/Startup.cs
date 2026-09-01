using Autofac;
using Autofac.Multitenant;

namespace AspNetCoreMultitenantExample;

public sealed class Startup
{
    public void ConfigureServices(IServiceCollection services)
    {
        // AddAutofacMultitenantRequestServices swaps the request's service
        // provider for the tenant's one. Without it every request resolves from
        // the application container and tenant overrides never apply.
        services
            .AddAutofacMultitenantRequestServices()
            .AddHttpContextAccessor()
            .AddControllers();
    }

    public void ConfigureContainer(ContainerBuilder builder)
    {
        // Registrations shared by all tenants, including the default that
        // tenant-specific registrations override.
        builder.RegisterType<DefaultDependency>()
            .As<ITenantDependency>()
            .InstancePerLifetimeScope();

        builder.RegisterType<QueryStringTenantIdentificationStrategy>()
            .As<ITenantIdentificationStrategy>()
            .SingleInstance();
    }

    public void Configure(IApplicationBuilder app)
    {
        app.UseRouting();
        app.UseEndpoints(endpoints => endpoints.MapControllers());
    }
}
