using System;

namespace MvcExample.Dependencies
{
    /// <summary>
    /// Simple dependency to show injection into a Razor view.
    /// </summary>
    public interface IViewDependency
    {
        /// <summary>
        /// Gets the unique instance ID for the dependency.
        /// </summary>
        /// <value>
        /// A <see cref="System.Guid"/> that indicates the unique ID for the
        /// instance.
        /// </value>
        Guid InstanceId { get; }
    }
}
