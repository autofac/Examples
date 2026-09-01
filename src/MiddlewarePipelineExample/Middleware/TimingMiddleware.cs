using System.Diagnostics;
using Autofac.Core.Resolving.Pipeline;

namespace MiddlewarePipelineExample.Middleware;

/// <summary>
/// Measures how long a resolve takes. Attached as service middleware, so it runs
/// for every resolve of the service regardless of which registration answers it.
/// </summary>
public sealed class TimingMiddleware : IResolveMiddleware
{
    private readonly Action<string> _report;

    public TimingMiddleware(Action<string> report) => _report = report;

    public PipelinePhase Phase => PipelinePhase.ResolveRequestStart;

    public void Execute(ResolveRequestContext context, Action<ResolveRequestContext> next)
    {
        var stopwatch = Stopwatch.StartNew();
        next(context);
        stopwatch.Stop();

        _report($"{context.Service} took {stopwatch.ElapsedMilliseconds}ms");
    }
}
