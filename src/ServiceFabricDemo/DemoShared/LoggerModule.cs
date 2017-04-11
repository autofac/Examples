using System;
using Autofac;

namespace DemoShared
{
    public class LoggerModule : Module
    {
        private readonly Action<string> _logAction;

        public LoggerModule(Action<string> logAction)
        {
            _logAction = logAction;
        }

        protected override void Load(ContainerBuilder builder)
        {
            builder.RegisterGeneric(typeof(Logger<>))
                .As(typeof(ILogger<>))
                .WithParameter(TypedParameter.From(_logAction))
                .InstancePerLifetimeScope();
        }
    }
}
