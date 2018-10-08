using ConfigurationExampleInterface;
using System;
using System.Collections.Generic;
using System.Text;

namespace ConfigurationExample
{
    /// <summary>
    /// Implementation of the plugin interface that will be loaded from a default assembly. This will be registered
    /// via configuration rather than code.
    /// </summary>
    public class InternalPlugin : IPlugin
    {
        /// <summary>
        /// Gets the name of the plugin.
        /// </summary>
        /// <value>
        /// Always returns <c>InternalPlugin</c>.
        /// </value>
        public string Name
        {
            get
            {
                return "InternalPlugin";
            }
        }
    }
}
