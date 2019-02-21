using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Reflection;
using System.Runtime.Loader;
using Autofac;
using Autofac.Configuration;
using ConfigurationExampleInterface;
using Microsoft.Extensions.Configuration;

namespace ConfigurationExample
{
    public class Program
    {
        /* Plugins and configuration can be challenging to figure out in .NET Core since assembly
         * loading and type handling has slightly changed. This example shows how to use configuration
         * to selectively load things. Additional examples and resources:
         * - Unit tests for Autofac.Configuration: https://github.com/autofac/Autofac.Configuration/tree/develop/test/Autofac.Configuration.Test
         * - Documentation for Autofac.Configuration: https://autofac.readthedocs.io/en/latest/configuration/xml.html
         *
         * To avoid referencing the external plugin assembly, the solution has a build dependency on the ConfigurationExamplePlugin
         * project and this project uses a post-build copy to get the plugin assembly into the ConfigurationExample bin directory.
         */
        public static void Main(string[] args)
        {
            // THIS IS THE MAGIC!
            // .NET Core assembly loading is confusing. Things that happen to be in your bin folder don't just suddenly
            // qualify with the assembly loader. If the assembly isn't specifically referenced by your app, you need to
            // tell .NET Core where to get it EVEN IF IT'S IN YOUR BIN FOLDER.
            // https://stackoverflow.com/questions/43918837/net-core-1-1-type-gettype-from-external-assembly-returns-null
            //
            // The documentation says that any .dll in the application base folder should work, but that doesn't seem
            // to be entirely true. You always have to set up additional handlers if you AREN'T referencing the plugin assembly.
            // https://github.com/dotnet/core-setup/blob/master/Documentation/design-docs/corehost.md
            //
            // To verify, try commenting this out and you'll see that the config system can't load the external plugin type.
            var executionFolder = Path.GetDirectoryName(typeof(Program).Assembly.Location);
            AssemblyLoadContext.Default.Resolving += (AssemblyLoadContext context, AssemblyName assembly) =>
            {
                // DISCLAIMER: NO PROMISES THIS IS SECURE. You may or may not want this strategy. It's up to
                // you to determine if allowing any assembly in the directory to be loaded is acceptable. This
                // is for demo purposes only.
                return context.LoadFromAssemblyPath(Path.Combine(executionFolder, $"{assembly.Name}.dll"));
            };

            var config = new ConfigurationBuilder()
                .AddJsonFile("autofac.json")
                .Build();
            var configModule = new ConfigurationModule(config);
            var builder = new ContainerBuilder();
            builder.RegisterModule(configModule);
            var container = builder.Build();

            try
            {
                // Always resolve from a scope.
                // https://autofac.readthedocs.io/en/latest/best-practices/index.html#always-resolve-dependencies-from-nested-lifetimes
                using (var scope = container.BeginLifetimeScope())
                {
                    var plugin = scope.Resolve<InternalPlugin>();
                    Console.WriteLine("Resolved specific plugin type: {0}", plugin.Name);

                    Console.WriteLine("All available plugins:");
                    var allPlugins = scope.Resolve<IEnumerable<IPlugin>>();
                    foreach (var resolved in allPlugins)
                    {
                        Console.WriteLine("- {0}", resolved.Name);
                    }
                }
            }
            catch (Exception ex)
            {
                Console.Error.WriteLine("Error during configuration demonstration: {0}", ex);
            }

            if (Debugger.IsAttached)
            {
                Console.WriteLine("Press any key to exit.");
                Console.ReadKey();
            }
        }
    }
}
