using System.Collections.Generic;
using System.Linq;
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
        var appender = _appenders.First(a => a.Metadata["AppenderName"].Equals(destination));
        appender.Value.Write(message);
    }
}
