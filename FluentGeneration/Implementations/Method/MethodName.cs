using System;
using FluentGeneration.Interfaces.Method;
using FluentGeneration.Shared;

namespace FluentGeneration.Implementations.Method
{
    public class MethodName<T> : IMethodName<T>
        where T : IGeneratedObject
    {
        private readonly IMethodAttribute<T> _methodAttribute;

        private Func<T> _source;
        public Func<T> Source
        {
            get => _source;
            set
            {
                _source = value;
                _methodAttribute.Source = value;
            }
        }

        public MethodName(IMethodAttribute<T> methodAttribute)
        {
            _methodAttribute = methodAttribute ?? throw new ArgumentNullException(nameof(methodAttribute));
        }

        public IMethodAttribute<T> WithName(string name)
        {
            Source.Invoke().Generator.AddGenerationData(typeof(IMethodName<>), name);
            return _methodAttribute;
        }
    }
}