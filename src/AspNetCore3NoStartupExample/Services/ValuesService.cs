using System.Collections.Generic;
using Microsoft.Extensions.Logging;

namespace AspNetCore3NoStartupExample.Services
{
    public class ValuesService : IValuesService
    {
        private readonly ILogger<ValuesService> _logger;

        public ValuesService(ILogger<ValuesService> logger)
        {
            this._logger = logger;
        }

        public IEnumerable<string> FindAll()
        {
            this._logger.LogDebug("{method} called", nameof(this.FindAll));

            return new[] { "value1", "value2" };
        }

        public string Find(int id)
        {
            this._logger.LogDebug("{method} called with {id}", nameof(this.Find), id);

            return $"value{id}";
        }
    }
}
