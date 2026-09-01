# DynamicProxyExample

Method interception with Castle DynamicProxy, wired up two ways: named on the registration, and declared with an `[Intercept]` attribute on the contract. The interceptor is a normal registration, so it can take dependencies of its own.

Packages: [`Autofac`](https://github.com/autofac/Autofac), [`Autofac.Extras.DynamicProxy`](https://github.com/autofac/Autofac.Extras.DynamicProxy)

Run `dotnet run --project src/DynamicProxyExample`. It prints the intercepted calls around each method.

See [Type Interceptors](https://autofac.readthedocs.io/en/latest/advanced/interceptors.html) for the documentation this example follows.
