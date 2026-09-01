# GenericHostBuilderExample

Autofac under the generic host, without ASP.NET Core in the picture. This is the shape to copy for a worker service or a console application that wants hosted services and configuration.

Packages: `Autofac.Extensions.DependencyInjection`

Run `dotnet run --project src/GenericHostBuilderExample`. It starts a hosted service and runs until you press Ctrl+C.

See [.NET Core](https://autofac.readthedocs.io/en/latest/integration/netcore.html) for the documentation this example follows.
