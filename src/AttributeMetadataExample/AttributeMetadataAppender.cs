using System;

namespace AttributeMetadataExample;

[AppenderName("attributed")]
public class AttributeMetadataAppender : ILogAppender
{
    public void Write(string message)
    {
        Console.WriteLine("Attribute Metadata: {0}", message);
    }
}
