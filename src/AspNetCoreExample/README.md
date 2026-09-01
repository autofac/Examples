# AspNetCoreExample

Wiring Autofac into ASP.NET Core through a `Startup` class, where `ConfigureContainer` receives a strongly-typed `ContainerBuilder` and registrations are grouped into a module.

Packages: [`Autofac.Extensions.DependencyInjection`](https://github.com/autofac/Autofac.Extensions.DependencyInjection)

Run `dotnet run --project src/AspNetCoreExample`, then browse to <http://localhost:5000/api/values>.

See [ASP.NET Core](https://autofac.readthedocs.io/en/latest/integration/aspnetcore.html) for the documentation this example follows.
