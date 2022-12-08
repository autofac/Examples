namespace AspNetCore3ChildLifetimeScope.Services
{
    public class ApplicationBScopedDependency
    {
        public override string ToString()
        {
            return $"{this.GetType().Name} registered only for ApplicationB";
        }
    }
}
