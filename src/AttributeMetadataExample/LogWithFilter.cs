using System;
using System.Linq;
using Autofac.Extras.AttributeMetadata;
using Autofac.Features.AttributeFilters;

namespace AttributeMetadataExample
{
    public class LogWithFilter
    {
        private readonly ILogAppender _appender;

        public LogWithFilter([MetadataFilter("AppenderName", "attributed")]ILogAppender appender)
        {
            this._appender = appender;
        }

        public void Write(string message)
        {
            this._appender.Write(message);
        }
    }
}
