using System;
using System.Linq;
using FluentGeneration.Interfaces.Class;

namespace FluentGeneration.Implementations.Class
{
    public class ClassAttribute : IClassAttribute
    {
        private readonly IClassGenericArguments _classGenericArguments;

        private Func<IClass> _source;
        public Func<IClass> Source
        {
            get => _source;
            set
            {
                _source = value;
                _classGenericArguments.Source = value;
            }
        }

        public ClassAttribute(IClassGenericArguments classGenericArguments)
        {
            _classGenericArguments = classGenericArguments;
        }

        public IClassGenericArguments WithAttributes(params Type[] attributeTypes)
        {
            if (attributeTypes.Any())
            {
                Source.Invoke().Generator.AddGenerationData(typeof(IClassAttribute), attributeTypes);
            }

            return _classGenericArguments;
        }

        public IClassGenericArguments WithAttributes(string literal)
        {
            if (!string.IsNullOrEmpty(literal))
            {
                Source.Invoke().Generator.AddGenerationData(typeof(IClassAttribute), literal);
            }

            return _classGenericArguments;
        }
    }
}