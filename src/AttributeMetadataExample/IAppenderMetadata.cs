using System;
using System.Linq;

namespace AttributeMetadataExample
{
    public interface IAppenderMetadata
    {
        string AppenderName { get; }
    }
}
