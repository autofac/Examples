using Autofac.Core;
using Autofac.Core.Lifetime;
using Autofac.Core.Resolving.Pipeline;

namespace MiddlewarePipelineExample.Middleware;

/// <summary>
/// Fails fast with a readable message when a service that expects a unit of work
/// is resolved straight from the root scope, where it would be captured for the
/// lifetime of the application.
/// </summary>
public sealed class RootScopeGuardMiddleware : IResolveMiddleware
{
    public PipelinePhase Phase => PipelinePhase.ScopeSelection;

    public void Execute(ResolveRequestContext context, Action<ResolveRequestContext> next)
    {
        if (Equals(context.ActivationScope.Tag, LifetimeScope.RootTag))
        {
            throw new DependencyResolutionException(
                $"{context.Service} must be resolved from a child lifetime scope, not the root container.");
        }

        next(context);
    }
}
