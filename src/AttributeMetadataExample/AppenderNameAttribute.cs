using System;
using System.ComponentModel.Composition;

namespace AttributeMetadataExample
{
    [MetadataAttribute]
    [AttributeUsage(AttributeTargets.Class)]
    public class AppenderNameAttribute : Attribute
    {
        public AppenderNameAttribute(string appenderName)
        {
            AppenderName = appenderName;
        }

        public string AppenderName { get; private set; }
    }
}
