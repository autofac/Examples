using System;
using System.Linq;
using Autofac.Extras.AttributeMetadata;

namespace AttributeMetadataExample
{
    public class LogWithFilter
    {
        private readonly ILogAppender _appender;

        public LogWithFilter([WithMetadata("AppenderName", "attributed")]ILogAppender appender)
        {
            this._appender = appender;
        }

        public void Write(string message)
        {
            this._appender.Write(message);
        }
    }
}
