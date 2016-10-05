using System;
using System.Linq;

namespace MvcExample.Dependencies
{
    /// <summary>
    /// Implementation of a simple dependency to inject into a filter.
    /// </summary>
    /// <seealso cref="MvcExample.Dependencies.IFilterDependency" />
    public class FilterDependency : IFilterDependency
    {
        /// <summary>
        /// Gets the current date and time as ticks.
        /// </summary>
        /// <value>
        /// An <see cref="System.Int64" /> with the current date and time as ticks.
        /// </value>
        public long CurrentTicks
        {
            get
            {
                return DateTime.UtcNow.Ticks;
            }
        }
    }
}