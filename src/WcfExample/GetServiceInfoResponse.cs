using System;
using System.ServiceModel;

namespace WcfExample
{
    /// <summary>
    /// Response message contract for the service info operation.
    /// </summary>
    [MessageContract]
    public class GetServiceInfoResponse
    {
        /// <summary>
        /// Gets or sets the service implementation type name.
        /// </summary>
        /// <value>
        /// A <see cref="System.String"/> with the service implementation type name to display.
        /// </value>
        [MessageBodyMember]
        public string ServiceImplementationTypeName { get; set; }

        /// <summary>
        /// Gets or sets the dependency instance ID.
        /// </summary>
        /// <value>
        /// A <see cref="System.Guid"/> that indicates the unique ID for the dependency instance.
        /// </value>
        [MessageBodyMember]
        public Guid DependencyInstanceId { get; set; }
    }
}