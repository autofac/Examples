using System;
using System.Threading;
using System.Threading.Tasks;
using Microsoft.ServiceFabric.Actors;
using Microsoft.ServiceFabric.Actors.Runtime;
using DemoActor.Interfaces;
using DemoShared;

namespace DemoActor
{
    /// <remarks>
    /// This class represents an actor.
    /// Every ActorID maps to an instance of this class.
    /// The StatePersistence attribute determines persistence and replication of actor state:
    ///  - Persisted: State is written to disk and replicated.
    ///  - Volatile: State is kept in memory only and replicated.
    ///  - None: State is kept in memory only and not replicated.
    /// </remarks>
    [StatePersistence(StatePersistence.Persisted)]
    public class DemoActor : Actor, IDemoActor, IDisposable
    {
        private readonly ILogger<DemoActor> _logger;

        /// <summary>
        /// Initializes a new instance of DemoActor
        /// </summary>
        /// <param name="actorService">The Microsoft.ServiceFabric.Actors.Runtime.ActorService that will host this actor instance.</param>
        /// <param name="actorId">The Microsoft.ServiceFabric.Actors.ActorId for this actor instance.</param>
        /// <param name="logger">An injected logger dependency.</param>
        public DemoActor(ActorService actorService, ActorId actorId, ILogger<DemoActor> logger)
            : base(actorService, actorId)
        {
            _logger = logger;

            _logger.Log("Constructed");
        }

        /// <summary>
        /// This method is called whenever an actor is activated.
        /// An actor is activated the first time any of its methods are invoked.
        /// </summary>
        protected override Task OnActivateAsync()
        {
            ActorEventSource.Current.ActorMessage(this, "Actor activated.");

            _logger.Log($"{nameof(OnActivateAsync)} invoked");

            // The StateManager is this actor's private state store.
            // Data stored in the StateManager will be replicated for high-availability for actors that use volatile or persisted state storage.
            // Any serializable object can be saved in the StateManager.
            // For more information, see https://aka.ms/servicefabricactorsstateserialization

            return this.StateManager.TryAddStateAsync("count", 0);
        }

        /// <summary>
        /// TODO: Replace with your own actor method.
        /// </summary>
        /// <returns></returns>
        Task<int> IDemoActor.GetCountAsync(CancellationToken cancellationToken)
        {
            _logger.Log($"{nameof(IDemoActor.GetCountAsync)} invoked");

            return this.StateManager.GetStateAsync<int>("count", cancellationToken);
        }

        /// <summary>
        /// TODO: Replace with your own actor method.
        /// </summary>
        /// <param name="count"></param>
        /// <returns></returns>
        Task IDemoActor.SetCountAsync(int count, CancellationToken cancellationToken)
        {
            _logger.Log($"{nameof(IDemoActor.SetCountAsync)} invoked");

            // Requests are not guaranteed to be processed in order nor at most once.
            // The update function here verifies that the incoming count is greater than the current count to preserve order.
            return this.StateManager.AddOrUpdateStateAsync("count", count, (key, value) => count > value ? count : value, cancellationToken);
        }

        protected override Task OnDeactivateAsync()
        {
            _logger.Log($"{nameof(OnDeactivateAsync)} invoked");

            return base.OnDeactivateAsync();
        }

        public void Dispose()
        {
            _logger.Log($"{nameof(Dispose)} invoked");
        }
    }
}
