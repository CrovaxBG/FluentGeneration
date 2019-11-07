using System;
using FluentGeneration.Interfaces.Interface;

namespace FluentGeneration.Implementations.Interface
{
    public class InterfaceName : IInterfaceName
    {
        private readonly IInterfaceAttribute _interfaceAttribute;

        private Func<IInterface> _source;
        public Func<IInterface> Source
        {
            get => _source;
            set
            {
                _source = value;
                _interfaceAttribute.Source = value;
            }
        }

        public InterfaceName(IInterfaceAttribute interfaceAttribute)
        {
            _interfaceAttribute = interfaceAttribute;
        }

        public IInterfaceAttribute WithName(string name)
        {
            Source.Invoke().Generator.AddGenerationData(typeof(IInterfaceName), name);
            return _interfaceAttribute;
        }
    }
}