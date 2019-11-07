using System;
using FluentGeneration.Interfaces.Interface;
using FluentGeneration.Shared;

namespace FluentGeneration.Implementations.Interface
{
    public class InterfaceAccessSpecifier : IInterfaceAccessSpecifier
    {
        private readonly IInterfaceName _interfaceName;

        private Func<IInterface> _source;
        public Func<IInterface> Source
        {
            get => _source;
            set
            {
                _source = value;
                _interfaceName.Source = value;
            }
        }

        public InterfaceAccessSpecifier(IInterfaceName interfaceName)
        {
            _interfaceName = interfaceName;
        }

        public IInterfaceName WithAccessSpecifier(AccessSpecifier accessSpecifier)
        {
            if (accessSpecifier != AccessSpecifier.None)
            {
                Source.Invoke().Generator.AddGenerationData(typeof(IInterfaceAccessSpecifier), accessSpecifier);
            }

            return _interfaceName;
        }
    }
}
