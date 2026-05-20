namespace AspNetCoreChildLifetimeScope.Services
{
    public class ApplicationAScopedDependency
    {
        public override string ToString()
        {
            return $"{GetType().Name} registered only for ApplicationA";
        }
    }
}
