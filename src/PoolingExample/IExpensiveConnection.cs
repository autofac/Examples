namespace PoolingExample;

public interface IExpensiveConnection
{
    /// <summary>
    /// Gets an identifier for this instance, so the example can show when an
    /// instance is reused rather than recreated.
    /// </summary>
    int Id
    {
        get;
    }

    /// <summary>
    /// Gets the number of times this instance has been used since it was last
    /// returned to the pool.
    /// </summary>
    int UseCount
    {
        get;
    }

    void Use();
}
