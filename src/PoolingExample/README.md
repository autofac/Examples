# PoolingExample

Reusing expensive instances across lifetime scopes instead of rebuilding them, and a pool policy that resets an instance on its way back into the pool. Watch the constructor log: sequential scopes share one instance, overlapping scopes each get their own.

Packages: [`Autofac`](https://github.com/autofac/Autofac), [`Autofac.Pooling`](https://github.com/autofac/Autofac.Pooling)

Run `dotnet run --project src/PoolingExample`. It reports which instance each scope received and how many were constructed in total.

See [Pooled Instances](https://autofac.readthedocs.io/en/latest/advanced/pooled-instances.html) for the documentation this example follows.
