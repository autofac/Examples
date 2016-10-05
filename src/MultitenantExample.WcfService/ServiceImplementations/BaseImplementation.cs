using System;
using Autofac.Multitenant;
using MultitenantExample.WcfService.Dependencies;

namespace MultitenantExample.WcfService.ServiceImplementations
{
    public class BaseImplementation : IMultitenantService, IMetadataConsumer
    {
        public BaseImplementation(IDependency dependency, ITenantIdentificationStrategy tenantIdStrategy)
        {
            this.Dependency = dependency;
            this.TenantIdentificationStrategy = tenantIdStrategy;
        }

        public IDependency Dependency { get; set; }

        public ITenantIdentificationStrategy TenantIdentificationStrategy { get; set; }

        public GetServiceInfoResponse GetServiceInfo()
        {
            return ServiceInfoBuilder.Build(this, this.Dependency, this.TenantIdentificationStrategy);
        }
    }
}