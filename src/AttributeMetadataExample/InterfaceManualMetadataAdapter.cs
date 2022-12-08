using System;

namespace AttributeMetadataExample;

public class InterfaceManualMetadataAdapter : ILogAppender
{
    public void Write(string message)
    {
        Console.WriteLine("Interface Metadata on Registration: {0}", message);
    }
}
