using Autofac.Features.Metadata;

namespace AttributeMetadataExample;

public class Log
{
    private readonly IEnumerable<Meta<ILogAppender>> _appenders;

    public Log(IEnumerable<Meta<ILogAppender>> appenders)
    {
        _appenders = appenders;
    }

    public void Write(string destination, string message)
    {
        var appender = _appenders.First(a => destination.Equals(a.Metadata["AppenderName"]));
        appender.Value.Write(message);
    }
}
