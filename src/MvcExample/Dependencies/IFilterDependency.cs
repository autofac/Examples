using System;
using System.Linq;

namespace MvcExample.Dependencies
{
    /// <summary>
    /// Simple dependency to show injection into an action filter.
    /// </summary>
    public interface IFilterDependency
    {
        /// <summary>
        /// Gets the current date and time as ticks.
        /// </summary>
        /// <value>
        /// An <see cref="System.Int64"/> with the current date and time as ticks.
        /// </value>
        long CurrentTicks { get; }
    }
}