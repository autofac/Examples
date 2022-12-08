namespace AspNetCore3ChildLifetimeScope.Services
{
    public class TransientChildScopeDependency
    {
        public override string ToString()
        {
            return $"{this.GetType().Name} registered in the specific scope for ApplicationA and ApplicationB";
        }
    }
}
