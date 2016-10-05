using System;
using System.Linq;
using WcfExample.Dependencies;

namespace WcfExample
{
    public class HostFactoryService : IService
    {
        public HostFactoryService(IDependency dependency)
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
