# AspNetCoreNoStartupExample

The same wiring as `AspNetCoreExample` using the minimal hosting model, with everything configured inline in `Program.cs` and no `Startup` class. Read the two side by side to see what the `Startup` class does and does not buy you.

Packages: `Autofac.Extensions.DependencyInjection`

Run `dotnet run --project src/AspNetCoreNoStartupExample`, then browse to <http://localhost:5000/api/values>.

See [ASP.NET Core](https://autofac.readthedocs.io/en/latest/integration/aspnetcore.html) for the documentation this example follows.
