using System;
using System.Threading.Tasks;

namespace GenericHostBuilderExample
{
    internal class Logger : ILogger
    {
        public async Task Log(string value)
        {
            await Console.Out.WriteLineAsync($"Logger: {value}");
        }
    }
}