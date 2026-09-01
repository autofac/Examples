using Autofac.Extras.DynamicProxy;

namespace DynamicProxyExample;

/// <summary>
/// The attribute names the interceptor here instead, which keeps the wiring next
/// to the contract rather than in the container configuration.
/// </summary>
[Intercept(typeof(CallLogger))]
public interface IGreeter
{
    string Greet(string name);
}
