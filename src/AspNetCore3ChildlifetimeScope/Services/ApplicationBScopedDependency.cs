namespace AspNetCore3ChildlifetimeScope.Services
{
    public class ApplicationBScopedDependency
    {
        public override string ToString()
        {
            return $"{this.GetType().Name} registered only for ApplicationB";
        }
    }
}