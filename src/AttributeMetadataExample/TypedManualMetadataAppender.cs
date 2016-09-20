using System;
using System.Linq;

namespace AttributeMetadataExample
{
    public class TypedManualMetadataAppender : ILogAppender
    {
        public void Write(string message)
        {
            Console.WriteLine("Strongly-Typed Metadata on Registration: {0}", message);
        }
    }
}
