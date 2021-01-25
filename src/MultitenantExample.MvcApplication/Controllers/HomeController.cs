using System;
using System.Web.Mvc;
using Autofac.Multitenant;
using MultitenantExample.MvcApplication.Dependencies;
using MultitenantExample.MvcApplication.Models;
using MultitenantExample.MvcApplication.WcfMetadataConsumer;
using MultitenantExample.MvcApplication.WcfService;

namespace MultitenantExample.MvcApplication.Controllers
{
    [HandleError]
    public class HomeController : Controller
    {
        public HomeController(IDependency dependency, ITenantIdentificationStrategy tenantIdStrategy, IMultitenantService standardService, IMetadataConsumer metadataService)
        {
            this.Dependency = dependency;
            this.TenantIdentificationStrategy = tenantIdStrategy;
            this.StandardServiceProxy = standardService;
            this.MetadataServiceProxy = metadataService;
        }

        public IDependency Dependency { get; set; }

        public IMetadataConsumer MetadataServiceProxy { get; set; }

        public IMultitenantService StandardServiceProxy { get; set; }

        public ITenantIdentificationStrategy TenantIdentificationStrategy { get; set; }

        public ActionResult About()
        {
            return View();
        }

        public virtual ActionResult Index()
        {
            var model = this.BuildIndexModel();
            return View(model);
        }

        protected virtual IndexModel BuildIndexModel()
        {
            var model = new IndexModel()
            {
                ControllerTypeName = this.GetType().Name,
                DependencyInstanceId = this.Dependency.InstanceId,
                DependencyTypeName = this.Dependency.GetType().Name,
                TenantId = this.GetTenantId(),
                StandardServiceInfo = this.StandardServiceProxy.GetServiceInfo(new MultitenantExample.MvcApplication.WcfService.GetServiceInfoRequest()),
                MetadataServiceInfo = this.MetadataServiceProxy.GetServiceInfo(new MultitenantExample.MvcApplication.WcfMetadataConsumer.GetServiceInfoRequest())
            };
            return model;
        }

        private object GetTenantId()
        {
            var success = this.TenantIdentificationStrategy.TryIdentifyTenant(out object tenantId);
            if (!success || tenantId == null)
            {
                return "[Default Tenant]";
            }
            return tenantId;
        }
    }
}
