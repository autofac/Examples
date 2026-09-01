# WebApiExample.OwinSelfHost

Web API 2 running under OWIN self-hosting rather than IIS, with Autofac supplying controller dependencies through the OWIN pipeline.

Packages: [`Autofac`](https://github.com/autofac/Autofac), [`Autofac.Owin`](https://github.com/autofac/Autofac.Owin), [`Autofac.WebApi2`](https://github.com/autofac/Autofac.WebApi), [`Autofac.WebApi2.Owin`](https://github.com/autofac/Autofac.WebApi.Owin)

Run `dotnet run --project src/WebApiExample.OwinSelfHost` on Windows. It self-hosts on <http://localhost:9123/> and calls itself once on startup.

See [OWIN](https://autofac.readthedocs.io/en/latest/integration/owin.html) for the documentation this example follows.
