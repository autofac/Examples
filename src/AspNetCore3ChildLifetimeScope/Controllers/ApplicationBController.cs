using AspNetCore3ChildLifetimeScope.Services;
using Autofac;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Hosting;

namespace AspNetCore3ChildLifetimeScope.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ApplicationBController : ControllerBase
    {
        private readonly ApplicationBScopedDependency _applicationBScopedDependency;
        private readonly TransientChildScopeDependency _transientChildScopeDependency;
        private readonly SingletonRootDependency _singletonRootDependency;

        public ApplicationBController(
            ApplicationBScopedDependency applicationBScopedDependency,
            TransientChildScopeDependency transientChildScopeDependency,
            SingletonRootDependency singletonRootDependency)
        {
            _applicationBScopedDependency = applicationBScopedDependency;
            _transientChildScopeDependency = transientChildScopeDependency;
            _singletonRootDependency = singletonRootDependency;
        }

        [HttpGet]
        public IActionResult ShowMessage() => Ok(new
        {
            Message =
                $"Resolved {nameof(ApplicationBScopedDependency)} from application-container. Resolved {nameof(TransientChildScopeDependency)} from {nameof(ILifetimeScope)} passed to the {nameof(IHost)}. Resolved {nameof(SingletonRootDependency)} from the container itself.",
            ApplicationBScopedDependency = _applicationBScopedDependency.ToString(),
            TransientRootChildScopeDependency = _transientChildScopeDependency.ToString(),
            TransientRootDependency = _singletonRootDependency.ToString(),
        });
    }
}
