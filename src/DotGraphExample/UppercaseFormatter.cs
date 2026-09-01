namespace DotGraphExample;

public sealed class UppercaseFormatter : IFormatter
{
    public string Format(string value) => value.ToUpperInvariant();
}
