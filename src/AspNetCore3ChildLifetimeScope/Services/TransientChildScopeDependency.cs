namespace AspNetCore3ChildLifetimeScope.Services
{
    public class TransientChildScopeDependency
    {
        public override string ToString()
        {
            return $"{GetType().Name} registered in the specific scope for ApplicationA and ApplicationB";
        }
    }
}
