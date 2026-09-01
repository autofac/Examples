# Autofac Examples

Example projects that consume and demonstrate [Autofac](https://autofac.org) functionality and integration.

[![Build status](https://github.com/autofac/Examples/actions/workflows/ci.yml/badge.svg)](https://github.com/autofac/Examples/actions/workflows/ci.yml)

## The Examples

Each example has its own README with what it shows and how to run it.

### ASP.NET Core

| Example | Demonstrates | Packages |
| --- | --- | --- |
| [AspNetCoreExample](src/AspNetCoreExample/README.md) | A `Startup` class whose `ConfigureContainer` takes a `ContainerBuilder` | [`Autofac.Extensions.DependencyInjection`](https://github.com/autofac/Autofac.Extensions.DependencyInjection) |
| [AspNetCoreNoStartupExample](src/AspNetCoreNoStartupExample/README.md) | The same wiring in the minimal hosting model, with no `Startup` class | [`Autofac.Extensions.DependencyInjection`](https://github.com/autofac/Autofac.Extensions.DependencyInjection) |
| [AspNetCoreChildLifetimeScope](src/AspNetCoreChildLifetimeScope/README.md) | Two hosts sharing one container, each rooted in its own child scope | [`Autofac.Extensions.DependencyInjection`](https://github.com/autofac/Autofac.Extensions.DependencyInjection) |
| [MultitenantExample.AspNetCore](src/MultitenantExample.AspNetCore/README.md) | Per-tenant registration overrides, with the tenant read from the query string | [`Autofac.AspNetCore.Multitenant`](https://github.com/autofac/Autofac.AspNetCore.Multitenant) |

### Hosting and core features

| Example | Demonstrates | Packages |
| --- | --- | --- |
| [GenericHostBuilderExample](src/GenericHostBuilderExample/README.md) | The generic host without ASP.NET Core, for worker services | [`Autofac.Extensions.DependencyInjection`](https://github.com/autofac/Autofac.Extensions.DependencyInjection) |
| [ConfigurationExample](src/ConfigurationExample/README.md) | Registering from `autofac.json`, including an unreferenced plugin assembly | [`Autofac.Configuration`](https://github.com/autofac/Autofac.Configuration) |
| [AttributeMetadataExample](src/AttributeMetadataExample/README.md) | Metadata by string, class, interface, and attribute, then filtering on it | [`Autofac.Extras.AttributeMetadata`](https://github.com/autofac/Autofac.Extras.AttributeMetadata) |
| [MultitenantExample.ConsoleApplication](src/MultitenantExample.ConsoleApplication/README.md) | Per-tenant overrides with no web request in sight | [`Autofac.Multitenant`](https://github.com/autofac/Autofac.Multitenant) |
| [DynamicProxyExample](src/DynamicProxyExample/README.md) | Method interception, wired both on the registration and by attribute | [`Autofac.Extras.DynamicProxy`](https://github.com/autofac/Autofac.Extras.DynamicProxy) |
| [PoolingExample](src/PoolingExample/README.md) | Reusing expensive instances across scopes, with a reset-on-return policy | [`Autofac.Pooling`](https://github.com/autofac/Autofac.Pooling) |
| [DotGraphExample](src/DotGraphExample/README.md) | Capturing a resolve operation as a Graphviz graph for troubleshooting | [`Autofac.Diagnostics.DotGraph`](https://github.com/autofac/Autofac.Diagnostics.DotGraph) |
| [MiddlewarePipelineExample](src/MiddlewarePipelineExample/README.md) | Resolve middleware for auditing, timing, caching, ambient state, and scope guards | [`Autofac`](https://github.com/autofac/Autofac) |

### .NET Framework

These target `net481` and need Windows. Most run under IIS Express from Visual Studio.

| Example | Demonstrates | Packages |
| --- | --- | --- |
| [MvcExample](src/MvcExample/README.md) | MVC 5 controllers, action filters, and view pages, plus a WCF client | [`Autofac.Mvc5`](https://github.com/autofac/Autofac.Mvc), [`Autofac.Wcf`](https://github.com/autofac/Autofac.Wcf) |
| [WebFormsExample](src/WebFormsExample/README.md) | Property injection into pages that cannot take constructor arguments | [`Autofac.Web`](https://github.com/autofac/Autofac.Web) |
| [WcfExample](src/WcfExample/README.md) | A WCF service whose implementation is resolved from the container | [`Autofac.Wcf`](https://github.com/autofac/Autofac.Wcf) |
| [WebApiExample.OwinSelfHost](src/WebApiExample.OwinSelfHost/README.md) | Web API 2 self-hosted under OWIN instead of IIS | [`Autofac.Owin`](https://github.com/autofac/Autofac.Owin), [`Autofac.WebApi2`](https://github.com/autofac/Autofac.WebApi), [`Autofac.WebApi2.Owin`](https://github.com/autofac/Autofac.WebApi.Owin) |
| [MultitenantExample.WcfService](src/MultitenantExample.WcfService/README.md) | A WCF service resolving a different implementation per tenant | [`Autofac.Multitenant.Wcf`](https://github.com/autofac/Autofac.Multitenant.Wcf), [`Autofac.Wcf`](https://github.com/autofac/Autofac.Wcf) |
| [MultitenantExample.MvcApplication](src/MultitenantExample.MvcApplication/README.md) | The client half, carrying tenant identity across the service boundary | [`Autofac.Multitenant`](https://github.com/autofac/Autofac.Multitenant), [`Autofac.Mvc5`](https://github.com/autofac/Autofac.Mvc) |

`ConfigurationExampleInterface` and `ConfigurationExamplePlugin` are supporting libraries for `ConfigurationExample` rather than examples themselves.

## Reading the Examples

The examples in the repo are always for the latest Autofac versions and libraries. Look at the tags on this repo to see examples for older and/or deprecated functionality.

The examples attempt to stick pretty close to the [Autofac documentation](https://autofac.readthedocs.io) so it helps to have that available.

[Open this repo in Visual Studio Code.](https://open.vscode.dev/autofac/Examples)

## Building the Examples

`Examples.slnx` contains every sample. The ASP.NET MVC, Web Forms, WCF, and OWIN self-host samples target .NET Framework, so building the whole solution requires Windows; the rest build anywhere.
