namespace PoolingExample;

/// <summary>
/// Stands in for something genuinely costly to construct, which is the only
/// reason to pool anything.
/// </summary>
public sealed class ExpensiveConnection : IExpensiveConnection
{
    private static int _created;

    public ExpensiveConnection()
    {
        Id = Interlocked.Increment(ref _created);
        Console.WriteLine($"  [constructed connection {Id}]");
    }

    public int Id
    {
        get;
    }

    public int UseCount
    {
        get; private set;
    }

    public static int CreatedCount => _created;

    public void Use() => UseCount++;

    /// <summary>
    /// Called by the pool policy on the way back into the pool. Pooled objects
    /// outlive the scope that used them, so anything request-specific has to be
    /// cleared or the next caller inherits it.
    /// </summary>
    public void Reset() => UseCount = 0;
}
