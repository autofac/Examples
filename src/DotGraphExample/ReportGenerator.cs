namespace DotGraphExample;

/// <summary>
/// Sits at the top of the graph, depending on a source and a formatter so the
/// trace has more than one level to draw.
/// </summary>
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
