using System;
using System.Diagnostics;
using System.Threading;
using System.Threading.Tasks;
using Autofac;
using Autofac.Integration.ServiceFabric;
using DemoActor.Interfaces;
using DemoShared;
using Microsoft.ServiceFabric.Actors;
using Microsoft.ServiceFabric.Actors.Client;

namespace DemoActor
{
    internal static class Program
    {
        /// <summary>
        /// This is the entry point of the service host process.
        /// </summary>
        private static void Main()
        {
            try
            {
                // The contents of your ServiceManifest.xml and ApplicationManifest.xml files
                // are automatically populated when you build this project.
                // For more information, see https://aka.ms/servicefabricactorsplatform

                // Start with the trusty old container builder.
                var builder = new ContainerBuilder();

                // Register any regular dependencies.
                builder.RegisterModule(new LoggerModule(ActorEventSource.Current.Message));

                // Register the Autofac magic for Service Fabric support.
                builder.RegisterServiceFabricSupport();

                // Register the actor service.
                builder.RegisterActor<DemoActor>();

                using (builder.Build())
                {
                    Task.Run(async () =>
                    {
                        // Invoke the actor to create an instance.
                        var actorId = ActorId.CreateRandom();
                        var actorProxy = ActorProxy.Create<IDemoActor>(actorId);
                        var count = actorProxy.GetCountAsync(new CancellationToken()).GetAwaiter().GetResult();

                        Debug.WriteLine($"Actor {actorId} has count {count}");

                        await Task.Delay(TimeSpan.FromSeconds(15));

                        // Delete the actor to trigger deactive.
                        var actorServiceProxy = ActorServiceProxy.Create(
                            new Uri("fabric:/AutofacServiceFabricDemo/DemoActorService"), actorId);

                        await actorServiceProxy.DeleteActorAsync(actorId, new CancellationToken());
                    });

                    Thread.Sleep(Timeout.Infinite);
                }
            }
            catch (Exception e)
            {
                ActorEventSource.Current.ActorHostInitializationFailed(e.ToString());
                throw;
            }
        }
    }
}
