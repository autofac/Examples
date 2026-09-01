namespace AspNetCoreExample.Services;

public class ValuesService : IValuesService
{
    private readonly ILogger<ValuesService> _logger;

    public ValuesService(ILogger<ValuesService> logger)
    {
        _logger = logger;
    }

    public IEnumerable<string> FindAll()
    {
        _logger.LogDebug("{Method} called", nameof(FindAll));

        return new[] { "value1", "value2" };
    }

    public string Find(int id)
    {
        _logger.LogDebug("{Method} called with {Id}", nameof(Find), id);

        return $"value{id}";
    }
}
