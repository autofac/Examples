using AspNetCore3ChildLifetimeScope.Services;
using Autofac;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Hosting;

namespace AspNetCore3ChildLifetimeScope.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ApplicationAController : ControllerBase
    {
        private readonly ApplicationAScopedDependency _applicationAScopedDependency;
        private readonly TransientChildScopeDependency _transientRootChildScopeDependency;
        private readonly SingletonRootDependency _singletonRootDependency;

        public ApplicationAController(
            ApplicationAScopedDependency applicationAScopedDependency,
            TransientChildScopeDependency transientRootChildScopeDependency,
            SingletonRootDependency singletonRootDependency)
        {
            _applicationAScopedDependency = applicationAScopedDependency;
            _transientRootChildScopeDependency = transientRootChildScopeDependency;
            _singletonRootDependency = singletonRootDependency;
        }

        [HttpGet]
        public IActionResult ShowMessage() => Ok(new
        {
            Message =
                $"Resolved {nameof(ApplicationAScopedDependency)} from application-container. Resolved {nameof(TransientChildScopeDependency)} from {nameof(ILifetimeScope)} passed to the {nameof(IHost)}. Resolved {nameof(SingletonRootDependency)} from the container itself.",
            ApplicationBScopedDependency = _applicationAScopedDependency.ToString(),
            TransientRootChildScopeDependency = _transientRootChildScopeDependency.ToString(),
            TransientRootDependency = _singletonRootDependency.ToString(),
        });
    }
}
