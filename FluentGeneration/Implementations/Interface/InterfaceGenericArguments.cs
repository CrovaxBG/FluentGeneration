using System;
using System.Linq;
using FluentGeneration.Interfaces.Interface;
using FluentGeneration.Shared;

namespace FluentGeneration.Implementations.Interface
{
    public class InterfaceGenericArguments : IInterfaceGenericArguments
    {
        private readonly IInterfaceGenericArgumentsConstraints _interfaceGenericArgumentsConstraints;

        private Func<IInterface> _source;
        public Func<IInterface> Source
        {
            get => _source;
            set
            {
                _source = value;
                _interfaceGenericArgumentsConstraints.Source = value;
            }
        }

        public InterfaceGenericArguments(IInterfaceGenericArgumentsConstraints interfaceGenericArgumentsConstraints)
        {
            _interfaceGenericArgumentsConstraints = interfaceGenericArgumentsConstraints;
        }

        public IInterfaceGenericArgumentsConstraints WithGenericArguments(params IGenericArgument[] arguments)
        {
            if (arguments.Any())
            {
                Source.Invoke().Generator.AddGenerationData(typeof(IInterfaceGenericArguments), arguments);
            }

            return _interfaceGenericArgumentsConstraints;
        }
    }
}