namespace DynamicProxyExample;

public sealed class Calculator : ICalculator
{
    public int Add(int left, int right) => left + right;
}
