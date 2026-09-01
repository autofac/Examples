namespace AspNetCoreMultitenantExample;

/// <summary>
/// Registered only for specific tenants, to show the override winning over the
/// container-wide default.
/// </summary>
public sealed class TenantOverrideDependency : ITenantDependency
{
    private readonly string _tenantId;

    public TenantOverrideDependency(string tenantId) => _tenantId = tenantId;

    public string Describe() => $"TenantOverrideDependency registered specifically for tenant '{_tenantId}'";
}
