namespace DotGraphExample;

/// <summary>
/// A decorator, so the captured graph shows an adapter chain rather than a flat
/// list of unrelated services.
/// </summary>
public sealed class BracketFormatter : IFormatter
{
    private readonly IFormatter _inner;

    public BracketFormatter(IFormatter inner) => _inner = inner;

    public string Format(string value) => $"[{_inner.Format(value)}]";
}
