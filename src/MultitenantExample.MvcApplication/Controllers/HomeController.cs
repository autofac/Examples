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
            Dependency = dependency;
            TenantIdentificationStrategy = tenantIdStrategy;
            StandardServiceProxy = standardService;
            MetadataServiceProxy = metadataService;
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
            var model = BuildIndexModel();
            return View(model);
        }

        protected virtual IndexModel BuildIndexModel()
        {
            var model = new IndexModel()
            {
                ControllerTypeName = GetType().Name,
                DependencyInstanceId = Dependency.InstanceId,
                DependencyTypeName = Dependency.GetType().Name,
                TenantId = GetTenantId(),
                StandardServiceInfo = StandardServiceProxy.GetServiceInfo(new MultitenantExample.MvcApplication.WcfService.GetServiceInfoRequest()),
                MetadataServiceInfo = MetadataServiceProxy.GetServiceInfo(new MultitenantExample.MvcApplication.WcfMetadataConsumer.GetServiceInfoRequest())
            };
            return model;
        }

        private object GetTenantId()
        {
            var success = TenantIdentificationStrategy.TryIdentifyTenant(out object tenantId);
            if (!success || tenantId == null)
            {
                return "[Default Tenant]";
            }
            return tenantId;
        }
    }
}
