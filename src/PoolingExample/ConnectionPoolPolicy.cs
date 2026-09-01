using Autofac;
using Autofac.Core;
using Autofac.Pooling;

namespace PoolingExample;

/// <summary>
/// A policy is the hook for deciding how many instances to keep and what to do
/// as they leave and re-enter the pool.
/// </summary>
public sealed class ConnectionPoolPolicy : IPooledRegistrationPolicy<ExpensiveConnection>
{
    public int MaximumRetained => 2;

    public ExpensiveConnection Get(IComponentContext context, IEnumerable<Parameter> parameters, Func<ExpensiveConnection> getFromPool)
        => getFromPool();

    /// <summary>
    /// Returning <see langword="true"/> puts the instance back in the pool.
    /// Return <see langword="false"/> to discard it instead, which is how you
    /// evict an instance that has gone bad.
    /// </summary>
    public bool Return(ExpensiveConnection pooledObject)
    {
        pooledObject.Reset();
        return true;
    }
}
