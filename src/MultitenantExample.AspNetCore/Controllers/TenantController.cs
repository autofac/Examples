using Autofac.Multitenant;
using Microsoft.AspNetCore.Mvc;

namespace MultitenantExample.AspNetCore.Controllers;

[ApiController]
[Route("api/[controller]")]
public sealed class TenantController : ControllerBase
{
    private readonly ITenantDependency _dependency;
    private readonly ITenantIdentificationStrategy _strategy;

    public TenantController(ITenantDependency dependency, ITenantIdentificationStrategy strategy)
    {
        _dependency = dependency;
        _strategy = strategy;
    }

    [HttpGet]
    public IActionResult Get()
    {
        _strategy.TryIdentifyTenant(out var tenantId);

        return Ok(new
        {
            Tenant = tenantId as string ?? "(default)",
            Resolved = _dependency.Describe(),
        });
    }
}
