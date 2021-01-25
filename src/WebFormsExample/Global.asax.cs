using System;
using System.Linq;
using System.Web;
using System.Web.Routing;
using Autofac;
using Autofac.Integration.Web;
using Microsoft.AspNet.FriendlyUrls;
using WebFormsExample.Dependencies;

namespace WebFormsExample
{
    public class Global : HttpApplication, IContainerProviderAccessor
    {
        // Provider that holds the application container.
        static IContainerProvider _containerProvider;

        // Instance property that will be used by Autofac HttpModules
        // to resolve and inject dependencies.
        public IContainerProvider ContainerProvider
        {
            get { return _containerProvider; }
        }

        public static void RegisterRoutes(RouteCollection routes)
        {
            var settings = new FriendlyUrlSettings
            {
                AutoRedirectMode = RedirectMode.Permanent
            };
            routes.EnableFriendlyUrls(settings);
        }

        private void Application_Start(object sender, EventArgs e)
        {
            // Build up your application container and register your dependencies.
            var builder = new ContainerBuilder();
            builder.RegisterType<Dependency>().As<IDependency>();

            // Once you're done registering things, set the container
            // provider up with your registrations.
            _containerProvider = new ContainerProvider(builder.Build());

            // Standard web forms startup.
            RegisterRoutes(RouteTable.Routes);
        }
    }
}