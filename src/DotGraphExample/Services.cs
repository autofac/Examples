namespace DotGraphExample;

// A graph is only interesting if there is something to draw, so these services
// nest a couple of levels deep and include a decorator and a keyed service.
public interface IDataSource
{
    string Read();
}

public interface IFormatter
{
    string Format(string value);
}

public interface IReportGenerator
{
    string Generate();
}

public sealed class DataSource : IDataSource
{
    public string Read() => "42";
}

public sealed class UppercaseFormatter : IFormatter
{
    public string Format(string value) => value.ToUpperInvariant();
}

/// <summary>
/// A decorator, so the graph shows the adapter chain rather than a flat list.
/// </summary>
public sealed class BracketFormatter : IFormatter
{
    private readonly IFormatter _inner;

    public BracketFormatter(IFormatter inner) => _inner = inner;

    public string Format(string value) => $"[{_inner.Format(value)}]";
}

public sealed class ReportGenerator : IReportGenerator
{
    private readonly IDataSource _source;
    private readonly IFormatter _formatter;

    public ReportGenerator(IDataSource source, IFormatter formatter)
    {
        _source = source;
        _formatter = formatter;
    }

    public string Generate() => _formatter.Format(_source.Read());
}
