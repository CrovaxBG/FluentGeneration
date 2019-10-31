using System;
using System.Collections.Generic;
using Unity;
using Unity.Resolution;

namespace FluentGeneration.Resolvers
{
    public class UnityResolver : IDependencyResolver
    {
        private readonly IUnityContainer _container;

        public UnityResolver(IUnityContainer container)
        {
            _container = container;
        }

        public T Resolve<T>()
        {
            return _container.Resolve<T>();
        }

        public T Resolve<T>(params IConstructorArgument[] parameterArguments)
        {
            if (parameterArguments == null) { throw new ArgumentNullException(nameof(parameterArguments)); }

            var resolverOverrides = ConvertToUnityArguments(parameterArguments);
            return _container.Resolve<T>(resolverOverrides);
        }

        private ResolverOverride[] ConvertToUnityArguments(IReadOnlyList<IConstructorArgument> parameterArguments)
        {
            var parameterOverrides = new ResolverOverride[parameterArguments.Count];
            for (int i = 0; i < parameterArguments.Count; i++)
            {
                parameterOverrides[i] = new ParameterOverride(parameterArguments[i].Name, parameterArguments[i].Value);
            }

            return parameterOverrides;
        }

        public IEnumerable<T> ResolveAll<T>()
        {
            return _container.ResolveAll<T>();
        }

        public void Dispose()
        {
            _container?.Dispose();
        }
    }
}