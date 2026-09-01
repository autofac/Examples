namespace GenericHostBuilderExample;

internal sealed class Logger : ILogger
{
    public async Task Log(string value)
    {
        await Console.Out.WriteLineAsync($"Logger: {value}");
    }
}
