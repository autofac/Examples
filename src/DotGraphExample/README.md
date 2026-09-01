# DotGraphExample

Capturing a resolve operation as a Graphviz graph, which is the fastest way to see what Autofac actually did when a resolve surprises you. The registrations include a decorator so the graph has an adapter chain worth looking at.

Packages: [`Autofac`](https://github.com/autofac/Autofac), [`Autofac.Diagnostics.DotGraph`](https://github.com/autofac/Autofac.Diagnostics.DotGraph)

Run `dotnet run --project src/DotGraphExample`. It writes a `.dot` file next to the built assembly and prints the Graphviz command to render it.

See [Tracing](https://autofac.readthedocs.io/en/latest/troubleshooting/tracing.html) for the documentation this example follows.
