using AspNetCore3ChildlifetimeScope.Services;
using Autofac;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Hosting;

namespace AspNetCore3ChildlifetimeScope.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ApplicationAController : ControllerBase
    {
        private readonly ApplicationAScopedDependency applicationAScopedDependency;
        private readonly TransientChildScopeDependency transientRootChildScopeDependency;
        private readonly SingletonRootDependency singletonRootDependency;

        public ApplicationAController(
            ApplicationAScopedDependency applicationAScopedDependency,
            TransientChildScopeDependency transientRootChildScopeDependency,
            SingletonRootDependency singletonRootDependency)
        {
            this.applicationAScopedDependency = applicationAScopedDependency;
            this.transientRootChildScopeDependency = transientRootChildScopeDependency;
            this.singletonRootDependency = singletonRootDependency;
        }

        [HttpGet]
        public IActionResult ShowMessage() => this.Ok(new
        {
            Message =
                $"Resolved {nameof(ApplicationAScopedDependency)} from application-container. Resolved {nameof(TransientChildScopeDependency)} from {nameof(ILifetimeScope)} passed to the {nameof(IHost)}. Resolved {nameof(SingletonRootDependency)} from the container itself.",
            ApplicationBScopedDependency = this.applicationAScopedDependency.ToString(),
            TransientRootChildScopeDependency = this.transientRootChildScopeDependency.ToString(),
            TransientRootDependency = this.singletonRootDependency.ToString(),
        });
    }
}