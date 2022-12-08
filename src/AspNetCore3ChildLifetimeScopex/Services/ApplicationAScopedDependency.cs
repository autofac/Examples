using System;
using Autofac.Extensions.DependencyInjection;

namespace AspNetCore3ChildlifetimeScope.Services
{
    public class ApplicationAScopedDependency
    {
        public override string ToString()
        {
            return $"{this.GetType().Name} registered only for ApplicationA";
        }
    }
}