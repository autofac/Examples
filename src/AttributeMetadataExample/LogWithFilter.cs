using Autofac.Features.AttributeFilters;

namespace AttributeMetadataExample
{
    public class LogWithFilter
    {
        private readonly ILogAppender _appender;

        public LogWithFilter([MetadataFilter("AppenderName", "attributed")]ILogAppender appender)
        {
            _appender = appender;
        }

        public void Write(string message)
        {
            _appender.Write(message);
        }
    }
}
