# MultitenantExample.AspNetCore

Per-tenant registration overrides in an ASP.NET Core application, with the tenant taken from a `?tenant=` query string. Tenants without an override fall back to the container-wide default, which is the behaviour most people want to confirm.

Packages: [`Autofac.AspNetCore.Multitenant`](https://github.com/autofac/Autofac.AspNetCore.Multitenant)

Run `dotnet run --project src/MultitenantExample.AspNetCore`, then compare <http://localhost:5000/api/tenant>, <http://localhost:5000/api/tenant?tenant=alpha>, and <http://localhost:5000/api/tenant?tenant=gamma>.

See [Multitenant Applications](https://autofac.readthedocs.io/en/latest/advanced/multitenant.html) for the documentation this example follows.
