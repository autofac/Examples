using System;
using System.ComponentModel.Composition;
using System.Linq;

namespace AttributeMetadataExample
{
    [MetadataAttribute]
    [AttributeUsage(AttributeTargets.Class)]
    public class AppenderNameAttribute : Attribute
    {
        public AppenderNameAttribute(string appenderName)
        {
            this.AppenderName = appenderName;
        }

        public string AppenderName { get; private set; }
    }
}
