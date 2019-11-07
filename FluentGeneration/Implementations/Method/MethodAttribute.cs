using System;
using System.Linq;
using FluentGeneration.Interfaces.Method;
using FluentGeneration.Shared;

namespace FluentGeneration.Implementations.Method
{
    public class MethodAttribute<T> : IMethodAttribute<T>
        where T : IGeneratedObject
    {
        private readonly MethodGenericArguments<T> _methodGenericArguments;

        private Func<T> _source;
        public Func<T> Source
        {
            get => _source;
            set
            {
                _source = value;
                _methodGenericArguments.Source = value;
            }
        }

        public MethodAttribute(MethodGenericArguments<T> methodGenericArguments)
        {
            _methodGenericArguments = methodGenericArguments ?? throw new ArgumentNullException(nameof(methodGenericArguments));
        }

        public IMethodGenericArguments<T> WithAttributes(params Type[] attributeTypes)
        {
            if (attributeTypes != null && attributeTypes.Any())
            {
                Source.Invoke().Generator.AddGenerationData(typeof(IMethodAttribute<>), attributeTypes);
            }

            return _methodGenericArguments;
        }

        public IMethodGenericArguments<T> WithAttributes(string literal)
        {
            if (!string.IsNullOrEmpty(literal))
            {
                Source.Invoke().Generator.AddGenerationData(typeof(IMethodAttribute<>), literal);
            }

            return _methodGenericArguments;
        }
    }
}