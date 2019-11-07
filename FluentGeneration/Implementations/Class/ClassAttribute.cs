using System;
using System.Linq;
using FluentGeneration.Interfaces.Class;
using FluentGeneration.Shared;

namespace FluentGeneration.Implementations.Class
{
    public class ClassAttribute<T> : IClassAttribute<T>
        where T : IGeneratedObject
    {
        private readonly IClassGenericArguments<T> _classGenericArguments;

        private Func<T> _source;
        public Func<T> Source
        {
            get => _source;
            set
            {
                _source = value;
                _classGenericArguments.Source = value;
            }
        }

        public ClassAttribute(IClassGenericArguments<T> classGenericArguments)
        {
            _classGenericArguments = classGenericArguments;
        }

        public IClassGenericArguments<T> WithAttributes(params Type[] attributeTypes)
        {
            if (attributeTypes.Any())
            {
                Source.Invoke().Generator.AddGenerationData(typeof(IClassAttribute<>), attributeTypes);
            }

            return _classGenericArguments;
        }

        public IClassGenericArguments<T> WithAttributes(string literal)
        {
            if (!string.IsNullOrEmpty(literal))
            {
                Source.Invoke().Generator.AddGenerationData(typeof(IClassAttribute<>), literal);
            }

            return _classGenericArguments;
        }
    }
}