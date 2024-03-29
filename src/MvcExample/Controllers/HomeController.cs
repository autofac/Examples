﻿using System.Threading.Tasks;
using System.Web.Mvc;
using MvcExample.HostFactoryService;
using MvcExample.Models;

namespace MvcExample.Controllers
{
    public class HomeController : Controller
    {
        public HomeController(IService serviceClient)
        {
            ServiceClient = serviceClient;
        }

        public IService ServiceClient { get; private set; }

        public ActionResult About()
        {
            return View();
        }

        [CustomActionFilter]
        public async Task<ActionResult> Index()
        {
            var serviceInfo = await ServiceClient.GetServiceInfoAsync(new GetServiceInfoRequest());

            var model = new DependencyValueModel
            {
                // Comes from a dependency in the custom action filter.
                FilterValue = (long)HttpContext.Items["filterValue"],

                // Comes from a dependency injected into the WCF service.
                WcfServiceDependencyId = serviceInfo.DependencyInstanceId
            };

            return View(model);
        }
    }
}
