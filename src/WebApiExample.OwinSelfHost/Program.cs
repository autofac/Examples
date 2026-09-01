using System;
using System.Diagnostics;
using System.Net.Http;
using Microsoft.Owin.Hosting;

namespace WebApiExample.OwinSelfHost;

internal sealed class Program
{
    private static void Main()
    {
        const string BaseAddress = "http://localhost:9123/";

        // This starts the OWIN host using the application startup
        // logic in the Startup class. See Startup for the example of
        // how to set up OWIN Web API.
        using (WebApp.Start<Startup>(BaseAddress))
        {
            // On startup this app will make a request to the self-hosted
            // Web API service. You should see logging statements and results
            // dumped to the console window.
            var client = new HttpClient();
            var response = client.GetAsync(BaseAddress + "api/test").Result;

            Console.WriteLine(response);
            Console.WriteLine(response.Content.ReadAsStringAsync().Result);
        }

        if (Debugger.IsAttached)
        {
            Console.WriteLine("Press any key to exit.");
            Console.ReadLine();
        }
    }
}
