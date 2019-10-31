using System;
using System.Collections.Generic;
using System.Linq;
using Unity;
using Unity.Lifetime;
using Unity.Resolution;

namespace FluentGeneration
{
    public static class PatternConfig
    {
        public static string FieldPattern { get; set; } = $@"
{{[IFieldAttribute<>]}}{Environment.NewLine}
{{[IFieldAccessSpecifier<>]}} {{[IFieldAccessModifier<>]}} {{[IFieldType<>]}} {{[IFieldName<>]}} {{= [IFieldValue<>]}};";
    }

    public static class Configuration
    {
        public static IDependencyResolver DependencyResolver { get; set; }
        public static IPatternResolver PattenResolver { get; set; }
    }

    public interface IDependencyResolver : IDisposable
    {
        T Resolve<T>();
        T Resolve<T>(params IConstructorArgument[] parameterArguments);

        IEnumerable<T> ResolveAll<T>();
    }

    public interface IConstructorArgument
    {
        string Name { get; }
        object Value { get; }
    }

    public class ConstructorArgument : IConstructorArgument
    {
        public string Name { get; set; }
        public object Value { get; set; }
    }

    public class UnityResolver : IDependencyResolver
    {
        private readonly IUnityContainer _container;

        private UnityResolver(IUnityContainer container)
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