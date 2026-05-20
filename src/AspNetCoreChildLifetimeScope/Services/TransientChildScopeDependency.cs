namespace AspNetCoreChildLifetimeScope.Services
{
    public class TransientChildScopeDependency
    {
        public override string ToString()
        {
            return $"{GetType().Name} registered in the specific scope for ApplicationA and ApplicationB";
        }
    }
}
