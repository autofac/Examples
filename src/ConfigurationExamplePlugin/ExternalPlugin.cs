using ConfigurationExampleInterface;
using System;

namespace ConfigurationExamplePlugin
{
    /// <summary>
    /// Implementation of the plugin interface that will be loaded from an external assembly. See the "ConfigurationExample"
    /// project for more details.
    /// </summary>
    public class ExternalPlugin : IPlugin
    {
        /// <summary>
        /// Gets the name of the plugin.
        /// </summary>
        /// <value>
        /// Always returns <c>ExternalPlugin</c>.
        /// </value>
        public string Name
        {
            get
            {
                return "ExternalPlugin";
            }
        }
    }
}
