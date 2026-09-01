# AspNetCoreChildLifetimeScope

Two ASP.NET Core hosts in one process, each rooted in its own child lifetime scope over a shared container, so both reach the same singletons while keeping their own per-application registrations.

Packages: `Autofac.Extensions.DependencyInjection`

Run `dotnet run --project src/AspNetCoreChildLifetimeScope`, then browse to <http://localhost:5000/api/ApplicationA> and <http://localhost:5001/api/ApplicationB>.

See [ASP.NET Core](https://autofac.readthedocs.io/en/latest/integration/aspnetcore.html) for the documentation this example follows.
