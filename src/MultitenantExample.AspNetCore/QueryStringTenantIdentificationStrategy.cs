using Autofac.Multitenant;

namespace MultitenantExample.AspNetCore;

/// <summary>
/// Identifies the tenant from a <c>?tenant=</c> query string value. A real
/// application would more likely use the host name, a claim, or a header, but the
/// shape of the strategy is the same: look at ambient request state and hand back
/// an identifier.
/// </summary>
public sealed class QueryStringTenantIdentificationStrategy : ITenantIdentificationStrategy
{
    private readonly IHttpContextAccessor _accessor;

    public QueryStringTenantIdentificationStrategy(IHttpContextAccessor accessor) => _accessor = accessor;

    public bool TryIdentifyTenant(out object? tenantId)
    {
        tenantId = _accessor.HttpContext?.Request.Query["tenant"].FirstOrDefault();

        // Returning false means "no tenant", and the default tenant is used.
        return tenantId is string id && !string.IsNullOrWhiteSpace(id);
    }
}
