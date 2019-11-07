using System;
using System.Linq;
using FluentGeneration.Interfaces.Interface;
using FluentGeneration.Shared;

namespace FluentGeneration.Implementations.Interface
{
    public class InterfaceGenericArgumentsConstraints<T> : IInterfaceGenericArgumentsConstraints<T>
        where T : IGeneratedObject
    {
        private readonly IInterfaceInheritance<T> _interfaceInheritance;

        private Func<T> _source;
        public Func<T> Source
        {
            get => _source;
            set
            {
                _source = value;
                _interfaceInheritance.Source = value;
            }
        }

        public InterfaceGenericArgumentsConstraints(IInterfaceInheritance<T> interfaceInheritance)
        {
            _interfaceInheritance = interfaceInheritance;
        }

        public IInterfaceInheritance<T> WithGenericArgumentConstraint(params IGenericArgumentConstraint[] constraints)
        {
            if (constraints.Any())
            {
                Source.Invoke().Generator.AddGenerationData(typeof(IInterfaceGenericArgumentsConstraints<>), constraints);
            }

            return _interfaceInheritance;
        }

        public IInterfaceInheritance<T> WithGenericArgumentConstraint(string literal)
        {
            if (!string.IsNullOrEmpty(literal))
            {
                Source.Invoke().Generator.AddGenerationData(typeof(IInterfaceGenericArgumentsConstraints<>), literal);
            }

            return _interfaceInheritance;
        }
    }
}