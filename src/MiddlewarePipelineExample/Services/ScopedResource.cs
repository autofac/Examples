namespace MiddlewarePipelineExample.Services;

public sealed class ScopedResource : IScopedResource
{
    public string Use() => "scoped work";
}
