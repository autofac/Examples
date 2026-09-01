# MiddlewarePipelineExample

Five things resolve middleware is actually useful for, each in its own class: auditing every registration without naming the middleware on any of them, timing a resolve, short-circuiting the pipeline from a cache, injecting ambient state as a parameter, and rejecting a resolve that came from the root scope.

The correlation ID scenario is the one worth reading twice. It runs in the parameter selection phase, which belongs to the registration pipeline, so it has to be attached with `ConfigurePipeline` rather than `RegisterServiceMiddleware`. Registering it as service middleware throws, and that error is the clearest explanation of why Autofac has two pipelines rather than one.

Packages: [`Autofac`](https://github.com/autofac/Autofac)

Run `dotnet run --project src/MiddlewarePipelineExample`. Each scenario prints a short section showing what the middleware did.

See [Resolve Pipelines](https://autofac.readthedocs.io/en/latest/advanced/pipelines.html) for the documentation this example follows.
