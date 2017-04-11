using System;
using System.Collections.Generic;
using System.Fabric;
using System.Threading;
using System.Threading.Tasks;
using DemoShared;
using Microsoft.ServiceFabric.Services.Communication.Runtime;
using Microsoft.ServiceFabric.Services.Runtime;

namespace DemoStatelessService
{
    /// <summary>
    /// An instance of this class is created for each service instance by the Service Fabric runtime.
    /// </summary>
    public class DemoStatelessService : StatelessService, IDisposable
    {
        private readonly ILogger<DemoStatelessService> _logger;

        public DemoStatelessService(StatelessServiceContext context, ILogger<DemoStatelessService> logger)
            : base(context)
        {
            _logger = logger;

            _logger.Log("Constructed");
        }

        /// <summary>
        /// Optional override to create listeners (e.g., TCP, HTTP) for this service replica to handle client or user requests.
        /// </summary>
        /// <returns>A collection of listeners.</returns>
        protected override IEnumerable<ServiceInstanceListener> CreateServiceInstanceListeners()
        {
            return new ServiceInstanceListener[0];
        }

        /// <summary>
        /// This is the main entry point for your service instance.
        /// </summary>
        /// <param name="cancellationToken">Canceled when Service Fabric needs to shut down this service instance.</param>
        protected override async Task RunAsync(CancellationToken cancellationToken)
        {
            // TODO: Replace the following sample code with your own logic 
            //       or remove this RunAsync override if it's not needed in your service.

            _logger.Log($"{nameof(RunAsync)} invoked");

            long iterations = 0;

            while (true)
            {
                cancellationToken.ThrowIfCancellationRequested();

                ServiceEventSource.Current.ServiceMessage(this.Context, "Working-{0}", ++iterations);

                await Task.Delay(TimeSpan.FromSeconds(1), cancellationToken);

                if (iterations != 30) continue;

                // Restart the replica after 30 seconds to trigger deactivate.
                var fabricClient = new FabricClient();
                await fabricClient.ServiceManager.RemoveReplicaAsync(
                    Context.NodeContext.NodeName, Context.PartitionId, Context.ReplicaOrInstanceId);
            }
        }

        protected override Task OnCloseAsync(CancellationToken cancellationToken)
        {
            _logger.Log($"{nameof(OnCloseAsync)} invoked");

            return base.OnCloseAsync(cancellationToken);
        }

        protected override void OnAbort()
        {
            _logger.Log($"{nameof(OnAbort)} invoked");

            base.OnAbort();
        }

        public void Dispose()
        {
            _logger.Log($"{nameof(Dispose)} invoked");
        }
    }
}
