using System;
using System.Linq;

namespace AttributeMetadataExample
{
    public interface ILogAppender
    {
        void Write(string message);
    }
}
