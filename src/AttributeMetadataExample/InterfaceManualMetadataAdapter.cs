using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AttributeMetadataExample
{
    public class InterfaceManualMetadataAdapter : ILogAppender
    {
        public void Write(string message)
        {
            Console.WriteLine("Interface Metadata on Registration: {0}", message);
        }
    }
}
