namespace AspNetCoreChildLifetimeScope.Services
{
    public class ApplicationBScopedDependency
    {
        public override string ToString()
        {
            return $"{GetType().Name} registered only for ApplicationB";
        }
    }
}
