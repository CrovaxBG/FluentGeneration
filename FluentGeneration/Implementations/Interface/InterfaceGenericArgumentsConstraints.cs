using System;
using System.Linq;
using FluentGeneration.Interfaces.Interface;
using FluentGeneration.Shared;

namespace FluentGeneration.Implementations.Interface
{
    public class InterfaceGenericArgumentsConstraints : IInterfaceGenericArgumentsConstraints
    {
        private readonly IInterfaceInheritance _interfaceInheritance;

        private Func<IInterface> _source;
        public Func<IInterface> Source
        {
            get => _source;
            set
            {
                _source = value;
                _interfaceInheritance.Source = value;
            }
        }

        public InterfaceGenericArgumentsConstraints(IInterfaceInheritance interfaceInheritance)
        {
            _interfaceInheritance = interfaceInheritance;
        }

        public IInterfaceInheritance WithGenericArgumentConstraint(params IGenericArgumentConstraint[] constraints)
        {
            if (constraints.Any())
            {
                Source.Invoke().Generator.AddGenerationData(typeof(IInterfaceGenericArgumentsConstraints), constraints);
            }

            return _interfaceInheritance;
        }

        public IInterfaceInheritance WithGenericArgumentConstraint(string literal)
        {
            if (!string.IsNullOrEmpty(literal))
            {
                Source.Invoke().Generator.AddGenerationData(typeof(IInterfaceGenericArgumentsConstraints), literal);
            }

            return _interfaceInheritance;
        }
    }
}