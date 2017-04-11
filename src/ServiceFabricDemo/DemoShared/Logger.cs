using System;

namespace DemoShared
{
    public class Logger<TService> : ILogger<TService>
    {
        private readonly Action<string> _logAction;

        private static readonly string ServiceName = typeof(TService).Name;

        public Logger(Action<string> logAction)
        {
            _logAction = logAction;
        }

        public void Log(string message)
        {
            _logAction($"{ServiceName}: {message}");
        }
    }
}
