using System;
using System.Linq;
using System.Web;
using Autofac;
using Autofac.Integration.Wcf;
using WcfExample.Dependencies;

namespace WcfExample
{
    public class Global : HttpApplication
    {
        protected void Application_Start(object sender, EventArgs e)
        {
            // WCF integration docs are at:
            // http://autofac.readthedocs.io/en/latest/integration/wcf.html
            var builder = new ContainerBuilder();

            // Register your service implementations.
            builder.RegisterType<HostFactoryService>();
            builder.RegisterType<WebHostFactoryService>();

            // Register your dependencies.
            builder.RegisterType<Dependency>().As<IDependency>();

            // Set the dependency resolver. This works for both regular
            // WCF services and REST-enabled services.
            var container = builder.Build();
            AutofacHostFactory.Container = container;
        }
    }
}