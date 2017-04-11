namespace DemoShared
{
    public interface ILogger<TService>
    {
        void Log(string message);
    }
}