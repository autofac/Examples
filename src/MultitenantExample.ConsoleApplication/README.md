# MultitenantExample.ConsoleApplication

Per-tenant registration overrides outside a web application, showing that multitenancy is not tied to a request pipeline. Switch tenants interactively and watch which dependency and lifetime you get.

Packages: `Autofac`, `Autofac.Multitenant`

Run `dotnet run --project src/MultitenantExample.ConsoleApplication` and press 1-9 to pick a tenant, or 0 for the default tenant.

See [Multitenant Applications](https://autofac.readthedocs.io/en/latest/advanced/multitenant.html) for the documentation this example follows.
