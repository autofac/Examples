namespace AspNetCore3ChildLifetimeScope.Services
{
    public class SingletonRootDependency
    {
        public override string ToString()
        {
            return $"{GetType().Name} registered in the root and available to ApplicationA and ApplicationB";
        }
    }
}
