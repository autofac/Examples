using System.Web;
using Autofac.Multitenant;

namespace MultitenantExample.MvcApplication
{
    public class RequestParameterStrategy : ITenantIdentificationStrategy
    {
        public bool TryIdentifyTenant(out object tenantId)
        {
            // This is an EXAMPLE ONLY and is NOT RECOMMENDED.
            tenantId = null;
            try
            {
                var context = HttpContext.Current;
                if (context != null && context.Request != null)
                {
                    tenantId = context.Request.Params["tenant"];
                }
            }
            catch (HttpException)
            {
                // Happens at app startup in IIS 7.0
            }

            return tenantId != null;
        }
    }
}
