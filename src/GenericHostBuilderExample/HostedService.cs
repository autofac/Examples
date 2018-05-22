using System.Threading;
using System.Threading.Tasks;
using Microsoft.Extensions.Hosting;

namespace GenericHostBuilderExample
{
    internal class HostedService : IHostedService
    {
        private readonly ILogger _logger;

        // ReSharper disable once UnusedMember.Global
        public HostedService(ILogger logger)
        {
            _logger = logger;
        }

        public async Task StartAsync(CancellationToken cancellationToken)
        {
            await _logger.Log("Starting hosted service");
        }

        public async Task StopAsync(CancellationToken cancellationToken)
        {
            await _logger.Log("Stopping hosted service");
        }
    }
}