using System;
using System.Linq;

namespace AttributeMetadataExample
{
    public class StringManualMetadataAppender : ILogAppender
    {
        public void Write(string message)
        {
            Console.WriteLine("String Metadata on Registration: {0}", message);
        }
    }
}
