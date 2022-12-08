using System;
using Autofac.Multitenant;
using MultitenantExample.WcfService.Dependencies;

namespace MultitenantExample.WcfService.ServiceImplementations
{
    public class BaseImplementation : IMultitenantService, IMetadataConsumer
    {
        public BaseImplementation(IDependency dependency, ITenantIdentificationStrategy tenantIdStrategy)
        {
            Dependency = dependency;
            TenantIdentificationStrategy = tenantIdStrategy;
        }

        public IDependency Dependency { get; set; }

        public ITenantIdentificationStrategy TenantIdentificationStrategy { get; set; }

        public GetServiceInfoResponse GetServiceInfo()
        {
            return ServiceInfoBuilder.Build(this, Dependency, TenantIdentificationStrategy);
        }
    }
}
