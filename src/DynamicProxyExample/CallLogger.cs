using Castle.DynamicProxy;

namespace DynamicProxyExample;

/// <summary>
/// An interceptor sees every call made through the proxied interface.
/// <see cref="IInvocation.Proceed"/> runs the real implementation; anything
/// before or after that call is yours to do.
/// </summary>
public sealed class CallLogger : IInterceptor
{
    private readonly TextWriter _output;

    public CallLogger(TextWriter output) => _output = output;

    public void Intercept(IInvocation invocation)
    {
        _output.WriteLine($"  -> {invocation.Method.Name}({string.Join(", ", invocation.Arguments)})");
        invocation.Proceed();
        _output.WriteLine($"  <- {invocation.Method.Name} returned {invocation.ReturnValue}");
    }
}
