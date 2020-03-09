using AspNetCore3ChildlifetimeScope.Services;
using Autofac;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Hosting;

namespace AspNetCore3ChildlifetimeScope.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ApplicationBController : ControllerBase
    {
        private readonly ApplicationBScopedDependency applicationBScopedDependency;
        private readonly TransientChildScopeDependency transientChildScopeDependency;
        private readonly SingletonRootDependency singletonRootDependency;

        public ApplicationBController(
            ApplicationBScopedDependency applicationBScopedDependency,
            TransientChildScopeDependency transientChildScopeDependency,
            SingletonRootDependency singletonRootDependency)
        {
            this.applicationBScopedDependency = applicationBScopedDependency;
            this.transientChildScopeDependency = transientChildScopeDependency;
            this.singletonRootDependency = singletonRootDependency;
        }

        [HttpGet]
        public IActionResult ShowMessage() => this.Ok(new
        {
            Message =
                $"Resolved {nameof(ApplicationBScopedDependency)} from application-container. Resolved {nameof(TransientChildScopeDependency)} from {nameof(ILifetimeScope)} passed to the {nameof(IHost)}. Resolved {nameof(SingletonRootDependency)} from the container itself.",
            ApplicationBScopedDependency = this.applicationBScopedDependency.ToString(),
            TransientRootChildScopeDependency = this.transientChildScopeDependency.ToString(),
            TransientRootDependency = this.singletonRootDependency.ToString(),
        });
    }
}