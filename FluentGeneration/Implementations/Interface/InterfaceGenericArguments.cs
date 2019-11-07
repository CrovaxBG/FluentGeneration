using System;
using System.Linq;
using FluentGeneration.Interfaces.Interface;
using FluentGeneration.Shared;

namespace FluentGeneration.Implementations.Interface
{
    public class InterfaceGenericArguments<T> : IInterfaceGenericArguments<T>
        where T : IGeneratedObject
    {
        private readonly IInterfaceGenericArgumentsConstraints<T> _interfaceGenericArgumentsConstraints;

        private Func<T> _source;
        public Func<T> Source
        {
            get => _source;
            set
            {
                _source = value;
                _interfaceGenericArgumentsConstraints.Source = value;
            }
        }

        public InterfaceGenericArguments(IInterfaceGenericArgumentsConstraints<T> interfaceGenericArgumentsConstraints)
        {
            _interfaceGenericArgumentsConstraints = interfaceGenericArgumentsConstraints;
        }

        public IInterfaceGenericArgumentsConstraints<T> WithGenericArguments(params IGenericArgument[] arguments)
        {
            if (arguments.Any())
            {
                Source.Invoke().Generator.AddGenerationData(typeof(IInterfaceGenericArguments<>), arguments);
            }

            return _interfaceGenericArgumentsConstraints;
        }
    }
}