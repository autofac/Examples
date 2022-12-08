namespace ConfigurationExampleInterface
{
    /// <summary>
    /// Simple plugin interface used to illustrate assembly loading/plugin handling
    /// via configuration. See the "ConfigurationExample" project for usage.
    /// </summary>
    public interface IPlugin
    {
        /// <summary>
        /// Gets the name of the plugin.
        /// </summary>
        /// <value>
        /// A <see cref="string"/> with the plugin name. Likely just the type name for illustrative purposes.
        /// </value>
        string Name { get; }
    }
}
