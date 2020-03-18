using System.Threading.Tasks;
using AspNetCore3ChildlifetimeScope.Services;
using Autofac;
using Autofac.Extensions.DependencyInjection;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Hosting;

namespace AspNetCore3ChildlifetimeScope
{
    public static class Program
    {
        public static async Task Main(string[] args)
        {
            var containerBuilder = new ContainerBuilder();

            containerBuilder.RegisterType<SingletonRootDependency>()
                .AsSelf()
                .SingleInstance();

            var container = containerBuilder.Build();

            await using var scopeApplicationA = container.BeginLifetimeScope("ScopeApplicationA", builder =>
                builder.RegisterType<TransientChildScopeDependency>().AsSelf().InstancePerDependency());

            await using var scopeApplicationB = container.BeginLifetimeScope("ScopeApplicationB", builder =>
                builder.RegisterType<TransientChildScopeDependency>().AsSelf().InstancePerDependency());

            using var hostApplicationA = CreateHostForApplicationA(scopeApplicationA, args);

            using var hostApplicationB = CreateHostForApplicationB(scopeApplicationB, args);

            await Task.WhenAll(hostApplicationA.RunAsync(), hostApplicationB.RunAsync());
        }

        private static IHost CreateHostForApplicationA(ILifetimeScope scope, string[] args)
        {
            // This shows how each application can use a separate lifetime scope
            // as the "root" for the application, whilst sharing a common container
            // for common dependencies. Each application can get app-specific
            // dependencies, but common items can be registered outside the app.

            return Host.CreateDefaultBuilder(args)
                .UseServiceProviderFactory(new AutofacChildLifetimeScopeServiceProviderFactory(scope))
                .ConfigureWebHostDefaults(builder => builder.UseStartup<ApplicationAStartup>().UseUrls("http://localhost:5000"))
                .Build();
        }

        private static IHost CreateHostForApplicationB(ILifetimeScope scope, string[] args)
        {
            // This shows how each application can use a separate lifetime scope
            // as the "root" for the application, whilst sharing a common container
            // for common dependencies. Each application can get app-specific
            // dependencies, but common items can be registered outside the app.

            return Host.CreateDefaultBuilder(args)
                .UseServiceProviderFactory(new AutofacChildLifetimeScopeServiceProviderFactory(scope))
                .ConfigureWebHostDefaults(builder => builder.UseStartup<ApplicationBStartup>().UseUrls("http://localhost:5001"))
                .Build();
        }
    }
}