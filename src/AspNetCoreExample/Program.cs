using System;
using System.Linq;
using Autofac.Extensions.DependencyInjection;
using Microsoft.AspNetCore;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;

namespace AspNetCoreExample
{
    public class Program
    {
        public static void Main(string[] args)
        {
            // The ConfigureServices call here allows for
            // ConfigureContainer to be supported in Startup with
            // a strongly-typed ContainerBuilder. If you don't
            // have the call to AddAutofac here, you won't get
            // ConfigureContainer support. This also automatically
            // calls Populate to put services you register during
            // ConfigureServices into Autofac.
            var host = WebHost.CreateDefaultBuilder(args)
                .ConfigureServices(services => services.AddAutofac())
                .UseStartup<Startup>()
                .Build();

            host.Run();
        }
    }
}
