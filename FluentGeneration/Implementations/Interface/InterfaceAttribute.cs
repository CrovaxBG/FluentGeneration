using System;
using System.Linq;
using FluentGeneration.Interfaces.Interface;
using FluentGeneration.Shared;

namespace FluentGeneration.Implementations.Interface
{
    public class InterfaceAttribute<T> : IInterfaceAttribute<T>
        where T : IGeneratedObject
    {
        private readonly IInterfaceGenericArguments<T> _interfaceGenericArguments;

        private Func<T> _source;
        public Func<T> Source
        {
            get => _source;
            set
            {
                _source = value;
                _interfaceGenericArguments.Source = value;
            }
        }

        public InterfaceAttribute(IInterfaceGenericArguments<T> interfaceGenericArguments)
        {
            _interfaceGenericArguments = interfaceGenericArguments;
        }

        public IInterfaceGenericArguments<T> WithAttributes(params Type[] attributeTypes)
        {
            if (attributeTypes.Any())
            {
                Source.Invoke().Generator.AddGenerationData(typeof(IInterfaceAttribute<>), attributeTypes);
            }

            return _interfaceGenericArguments;
        }

        public IInterfaceGenericArguments<T> WithAttributes(string literal)
        {
            if (!string.IsNullOrEmpty(literal))
            {
                Source.Invoke().Generator.AddGenerationData(typeof(IInterfaceAttribute<>), literal);
            }

            return _interfaceGenericArguments;
        }
    }
}