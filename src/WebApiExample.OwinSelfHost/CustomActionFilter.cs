using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Web.Http.Controllers;
using System.Web.Http.Filters;
using Autofac.Integration.WebApi;

namespace WebApiExample.OwinSelfHost
{
    public class CustomActionFilter : IAutofacActionFilter
    {
        private readonly ILogger _logger;

        public CustomActionFilter(ILogger logger)
        {
            this._logger = logger;
        }

        public Task OnActionExecutedAsync(HttpActionExecutedContext actionExecutedContext, CancellationToken cancellationToken)
        {
            this._logger.Write("Inside the 'OnActionExecutedAsync' method of the custom action filter.");
            return Task.FromResult(0);
        }

        public Task OnActionExecutingAsync(HttpActionContext actionContext, CancellationToken cancellationToken)
        {
            this._logger.Write("Inside the 'OnActionExecutingAsync' method of the custom action filter.");
            return Task.FromResult(0);
        }
    }
}
