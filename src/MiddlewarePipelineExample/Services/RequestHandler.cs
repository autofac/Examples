namespace MiddlewarePipelineExample.Services;

/// <summary>
/// Takes a correlation identifier it has no way to know at registration time.
/// Middleware supplies it per resolve.
/// </summary>
public sealed class RequestHandler : IRequestHandler
{
    private readonly string _correlationId;

    public RequestHandler(string correlationId) => _correlationId = correlationId;

    public string Describe() => $"handling request {_correlationId}";
}
