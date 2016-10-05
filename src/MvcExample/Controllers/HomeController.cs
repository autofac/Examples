using System;
using System.Linq;
using System.Web.Mvc;
using MvcExample.Models;

namespace MvcExample.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult About()
        {
            return View();
        }

        [CustomActionFilter]
        public ActionResult Index()
        {
            var model = new DependencyValueModel
            {
                // Injected by the custom action filter.
                FilterValue = (long)this.HttpContext.Items["filterValue"]
            };

            return View(model);
        }
    }
}