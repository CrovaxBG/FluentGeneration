using System;
using System.Collections.Generic;

namespace FluentGeneration.Resolvers
{
    public interface IDependencyResolver : IDisposable
    {
        T Resolve<T>();
        T Resolve<T>(params IConstructorArgument[] parameterArguments);

        IEnumerable<T> ResolveAll<T>();
    }
}