using System;
using System.Linq;
using FluentGeneration.Interfaces.Interface;

namespace FluentGeneration.Implementations.Interface
{
    public class InterfaceAttribute : IInterfaceAttribute
    {
        private readonly IInterfaceGenericArguments _interfaceGenericArguments;

        private Func<IInterface> _source;
        public Func<IInterface> Source
        {
            get => _source;
            set
            {
                _source = value;
                _interfaceGenericArguments.Source = value;
            }
        }

        public InterfaceAttribute(IInterfaceGenericArguments interfaceGenericArguments)
        {
            _interfaceGenericArguments = interfaceGenericArguments ?? throw new ArgumentNullException(nameof(interfaceGenericArguments));
        }

        public IInterfaceGenericArguments WithAttributes(params Type[] attributeTypes)
        {
            if (attributeTypes != null && attributeTypes.Any())
            {
                Source.Invoke().Generator.AddGenerationData(typeof(IInterfaceAttribute), attributeTypes);
            }

            return _interfaceGenericArguments;
        }

        public IInterfaceGenericArguments WithAttributes(string literal)
        {
            if (!string.IsNullOrEmpty(literal))
            {
                Source.Invoke().Generator.AddGenerationData(typeof(IInterfaceAttribute), literal);
            }

            return _interfaceGenericArguments;
        }
    }
}