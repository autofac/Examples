using System;
using System.Linq;
using WcfExample.Dependencies;

namespace WcfExample
{
    /// <summary>
    /// REST-enabled version of the service. Call
    /// http://localhost:25665/WebHostFactoryService.svc/GetInfo
    /// to see this execute.
    /// </summary>
    /// <seealso cref="WcfExample.IService" />
    public class WebHostFactoryService : IService
    {
        public WebHostFactoryService(IDependency dependency)
        {
            this.Dependency = dependency;
        }

        public IDependency Dependency { get; private set; }

        public GetServiceInfoResponse GetServiceInfo()
        {
            return new GetServiceInfoResponse
            {
                DependencyInstanceId = this.Dependency.InstanceId,
                ServiceImplementationTypeName = this.GetType().FullName
            };
        }
    }
}
