using Autofac;
using Autofac.Multitenant;

namespace MultitenantExample.AspNetCore;

/// <summary>
/// Tenant overrides are configured here rather than in <c>Startup</c>, because
/// they need the built application container to construct the tenant
/// identification strategy from.
/// </summary>
public static class MultitenantContainerSetup
{
    public static MultitenantContainer ConfigureMultitenantContainer(IContainer container)
    {
        var strategy = new QueryStringTenantIdentificationStrategy(container.Resolve<IHttpContextAccessor>());
        var multitenantContainer = new MultitenantContainer(strategy, container);

        foreach (var tenantId in new[] { "alpha", "beta" })
        {
            var id = tenantId;
            multitenantContainer.ConfigureTenant(
                id,
                builder => builder
                    .Register(_ => new TenantOverrideDependency(id))
                    .As<ITenantDependency>()
                    .InstancePerLifetimeScope());
        }

        return multitenantContainer;
    }
}
