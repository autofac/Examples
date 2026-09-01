namespace DynamicProxyExample;

/// <summary>
/// Interception is wired up on the registration for this service, so the
/// interface itself needs to know nothing about it.
/// </summary>
public interface ICalculator
{
    int Add(int left, int right);
}
