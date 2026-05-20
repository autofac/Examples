using AspNetCoreNoStartupExample.Services;
using Autofac;
using Microsoft.Extensions.Logging;

namespace AspNetCoreNoStartupExample;

public class AutofacModule : Module
{
    protected override void Load(ContainerBuilder builder)
    {
        // The generic ILogger<TCategoryName> service was added to the
        // ServiceCollection by ASP.NET Core. It was then registered with
        // Autofac using the Populate method, which happens automatically
        // when using the AutofacServiceProviderFactory.
        builder.Register(c => new ValuesService(c.Resolve<ILogger<ValuesService>>()))
            .As<IValuesService>()
            .InstancePerLifetimeScope();
    }
}
