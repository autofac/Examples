# MultitenantExample.WcfService

A WCF service that resolves a different implementation per tenant, including how the tenant is identified from the incoming message.

Packages: `Autofac`, `Autofac.Multitenant`, `Autofac.Multitenant.Wcf`, `Autofac.Wcf`

Open `Examples.slnx` in Visual Studio on Windows and run the project under IIS Express. `MultitenantExample.MvcApplication` is its client.

See [Multitenant Applications](https://autofac.readthedocs.io/en/latest/advanced/multitenant.html) for the documentation this example follows.
