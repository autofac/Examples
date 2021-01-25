using System;
using System.Diagnostics;
using System.Linq;
using Autofac;
using Autofac.Extras.AttributeMetadata;
using Autofac.Features.AttributeFilters;
using Autofac.Integration.Mef;

namespace AttributeMetadataExample
{
    public class Program
    {
        private static void Main()
        {
            // Attribute metadata documentation can be found here:
            // https://autofac.readthedocs.io/en/latest/advanced/metadata.html
            var builder = new ContainerBuilder();
            builder.RegisterType<Log>();

            // Example: Attach string-based metadata manually through registration.
            builder.RegisterType<StringManualMetadataAppender>()
                .As<ILogAppender>()
                .WithMetadata("AppenderName", "string-manual");

            // Example: Attach strongly-typed metadata manually through registration.
            builder.RegisterType<TypedManualMetadataAppender>()
                .As<ILogAppender>()
                .WithMetadata<AppenderMetadata>(m => m.For(am => am.AppenderName, "typed-manual"));

            // Example: Attach interface-based metadata manually through registration.
            // Requires use of the RegisterMetadataRegistrationSources extension from Autofac.Mef.
            builder.RegisterType<InterfaceManualMetadataAdapter>()
                .As<ILogAppender>()
                .WithMetadata<IAppenderMetadata>(m => m.For(am => am.AppenderName, "interface-manual"));
            builder.RegisterMetadataRegistrationSources();

            // Example: Attribute-based metadata.
            // Requires registration of the AttributedMetadataModule.
            builder.RegisterType<AttributeMetadataAppender>()
                .As<ILogAppender>();
            builder.RegisterModule<AttributedMetadataModule>();

            // Example: Consuming component using metadata filter attribute in constructor.
            builder.RegisterType<LogWithFilter>()
                .WithAttributeFiltering();

            using (var container = builder.Build())
            {
                using var scope = container.BeginLifetimeScope();

                // The standard logger will choose which appender to use
                // based on the specified metadata value.
                var log = scope.Resolve<Log>();
                log.Write("string-manual", "Message 1");
                log.Write("typed-manual", "Message 2");
                log.Write("interface-manual", "Message 3");
                log.Write("attributed", "Message 4");

                // This logger selects the appropriate appender by
                // applying a filter attribute on the constructor parameter.
                var filteredLog = scope.Resolve<LogWithFilter>();
                filteredLog.Write("Message from filtered log");
            }

            if (Debugger.IsAttached)
            {
                Console.WriteLine("[press any key to exit]");
                Console.ReadKey();
            }
        }
    }
}
