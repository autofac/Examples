using System;
using System.Linq;

namespace MvcExample.Models
{
    /// <summary>
    /// Model used to gather values from dependencies and display them.
    /// </summary>
    public class DependencyValueModel
    {
        /// <summary>
        /// Gets or sets the value retrieved from the action filter.
        /// </summary>
        /// <value>
        /// An <see cref="System.Int64"/> with the current date and time as ticks.
        /// </value>
        public long FilterValue { get; set; }
    }
}