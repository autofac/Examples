using Autofac.Core.Resolving.Pipeline;

namespace MiddlewarePipelineExample.Middleware;

/// <summary>
/// Short-circuits the pipeline. Setting <see cref="ResolveRequestContext.Instance"/>
/// and never calling <c>next</c> means activation is skipped entirely, so nothing
/// downstream runs. Useful for a cache, and the reason middleware can be cheaper
/// than a registration that has to construct something to decide it wasn't needed.
/// </summary>
public sealed class CachingMiddleware : IResolveMiddleware
{
    private readonly Action<string> _report;
    private object? _cached;

    public CachingMiddleware(Action<string> report) => _report = report;

    public PipelinePhase Phase => PipelinePhase.ResolveRequestStart;

    public void Execute(ResolveRequestContext context, Action<ResolveRequestContext> next)
    {
        if (_cached is not null)
        {
            _report($"cache hit for {context.Service}, activation skipped");
            context.Instance = _cached;
            return;
        }

        next(context);
        _cached = context.Instance;
        _report($"cache miss for {context.Service}, instance stored");
    }
}
