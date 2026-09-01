namespace MiddlewarePipelineExample.Services;

/// <summary>
/// Expensive to construct, which is what makes the timing and caching middleware
/// worth looking at.
/// </summary>
public sealed class SlowService : ISlowService
{
    public SlowService() => Thread.Sleep(75);

    public string Fetch() => "data";
}
