using System;
using System.Linq;

namespace WebFormsExample.Dependencies
{
    /// <summary>
    /// Simple dependency implementation.
    /// </summary>
    public class Dependency : IDependency
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="Dependency"/> class.
        /// </summary>
        public Dependency()
        {
            InstanceId = Guid.NewGuid();
        }

        /// <summary>
        /// Gets the unique instance ID for the dependency.
        /// </summary>
        /// <value>
        /// A <see cref="System.Guid"/> that indicates the unique ID for the
        /// instance.
        /// </value>
        public Guid InstanceId { get; private set; }
    }
}
