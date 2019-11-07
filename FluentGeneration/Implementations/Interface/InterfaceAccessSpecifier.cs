using System;
using System.Collections.Generic;
using System.Text;
using FluentGeneration.Interfaces.Interface;
using FluentGeneration.Shared;

namespace FluentGeneration.Implementations.Interface
{
    public class InterfaceAccessSpecifier<T> : IInterfaceAccessSpecifier<T>
        where T : IGeneratedObject
    {
        private readonly IInterfaceName<T> _interfaceName;

        private Func<T> _source;
        public Func<T> Source
        {
            get => _source;
            set
            {
                _source = value;
                _interfaceName.Source = value;
            }
        }

        public InterfaceAccessSpecifier(IInterfaceName<T> interfaceName)
        {
            _interfaceName = interfaceName;
        }

        public IInterfaceName<T> WithAccessSpecifier(AccessSpecifier accessSpecifier)
        {
            if (accessSpecifier != AccessSpecifier.None)
            {
                Source.Invoke().Generator.AddGenerationData(typeof(IInterfaceAccessSpecifier<>), accessSpecifier);
            }

            return _interfaceName;
        }
    }
}
