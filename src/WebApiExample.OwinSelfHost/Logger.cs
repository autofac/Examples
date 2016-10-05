using System.Diagnostics;

namespace WebApiExample.OwinSelfHost
{
    public class Logger : ILogger
    {
        public void Write(string message, params object[] args)
        {
            Debug.WriteLine(message, args);
        }
    }
}
