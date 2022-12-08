using System;
using Autofac.Extensions.DependencyInjection;

namespace AspNetCore3ChildLifetimeScope.Services
{
    public class ApplicationAScopedDependency
    {
        public override string ToString()
        {
            return $"{this.GetType().Name} registered only for ApplicationA";
        }
    }
}
