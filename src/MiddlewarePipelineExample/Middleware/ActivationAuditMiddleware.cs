using Autofac.Core.Resolving.Pipeline;

namespace MiddlewarePipelineExample.Middleware;

/// <summary>
/// Applied to every registration in the container rather than named on each one.
/// This is the answer to wanting a hook that runs for all registered components
/// without calling an extension method on each registration in turn.
/// </summary>
public sealed class ActivationAuditMiddleware : IResolveMiddleware
{
    private readonly List<string> _log;

    public ActivationAuditMiddleware(List<string> log) => _log = log;

    public PipelinePhase Phase => PipelinePhase.RegistrationPipelineStart;

    public void Execute(ResolveRequestContext context, Action<ResolveRequestContext> next)
    {
        next(context);

        // The instance is available after next() returns, because that is when
        // the rest of the pipeline has run and activation has happened.
        if (context.NewInstanceActivated)
        {
            _log.Add(context.Instance!.GetType().Name);
        }
    }
}
