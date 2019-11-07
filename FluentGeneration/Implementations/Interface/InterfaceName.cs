using System;
using FluentGeneration.Interfaces.Interface;
using FluentGeneration.Shared;

namespace FluentGeneration.Implementations.Interface
{
    public class InterfaceName<T> : IInterfaceName<T>
        where T : IGeneratedObject
    {
        private readonly IInterfaceAttribute<T> _interfaceAttribute;

        private Func<T> _source;
        public Func<T> Source
        {
            get => _source;
            set
            {
                _source = value;
                _interfaceAttribute.Source = value;
            }
        }

        public InterfaceName(IInterfaceAttribute<T> interfaceAttribute)
        {
            _interfaceAttribute = interfaceAttribute;
        }

        public IInterfaceAttribute<T> WithName(string name)
        {
            Source.Invoke().Generator.AddGenerationData(typeof(IInterfaceName<>), name);
            return _interfaceAttribute;
        }
    }
}