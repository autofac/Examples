using System;
using System.Linq;
using WcfExample.Dependencies;

namespace WcfExample
{
    public class HostFactoryService : IService
    {
        public HostFactoryService(IDependency dependency)
        {
            Dependency = dependency;
        }

        public IDependency Dependency { get; private set; }

        public GetServiceInfoResponse GetServiceInfo()
        {
            return new GetServiceInfoResponse
            {
                DependencyInstanceId = Dependency.InstanceId,
                ServiceImplementationTypeName = GetType().FullName
            };
        }
    }
}
