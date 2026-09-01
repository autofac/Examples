using Autofac;
using Autofac.Core.Resolving.Pipeline;

namespace MiddlewarePipelineExample.Middleware;

/// <summary>
/// Injects ambient state into a resolve without every caller having to pass it.
/// The parameter has to be added before the constructor is chosen, which is why
/// this sits in the parameter selection phase.
/// </summary>
public sealed class CorrelationIdMiddleware : IResolveMiddleware
{
    private readonly Func<string> _currentCorrelationId;

    public CorrelationIdMiddleware(Func<string> currentCorrelationId) => _currentCorrelationId = currentCorrelationId;

    public PipelinePhase Phase => PipelinePhase.ParameterSelection;

    public void Execute(ResolveRequestContext context, Action<ResolveRequestContext> next)
    {
        context.ChangeParameters(
            context.Parameters.Concat([new NamedParameter("correlationId", _currentCorrelationId())]));

        next(context);
    }
}
