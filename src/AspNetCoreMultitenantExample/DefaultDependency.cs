namespace AspNetCoreMultitenantExample;

/// <summary>
/// What every tenant gets unless it registers an override.
/// </summary>
public sealed class DefaultDependency : ITenantDependency
{
    public string Describe() => "DefaultDependency, shared by every tenant without an override";
}
