using System;
using System.Linq;
using FluentGeneration.Interfaces.Class;
using FluentGeneration.Shared;

namespace FluentGeneration.Implementations.Class
{
    public class ClassGenericArgumentsConstraints : IClassGenericArgumentsConstraints
    {
        private readonly IClassInheritance _classInheritance;

        private Func<IClass> _source;
        public Func<IClass> Source
        {
            get => _source;
            set
            {
                _source = value;
                _classInheritance.Source = value;
            }
        }

        public ClassGenericArgumentsConstraints(IClassInheritance classInheritance)
        {
            _classInheritance = classInheritance;
        }

        public IClassInheritance WithGenericArgumentConstraint(params IGenericArgumentConstraint[] constraints)
        {
            if (constraints.Any())
            {
                Source.Invoke().Generator.AddGenerationData(typeof(IClassGenericArgumentsConstraints), constraints);
            }
            return _classInheritance;
        }

        public IClassInheritance WithGenericArgumentConstraint(string literal)
        {
            if (!string.IsNullOrEmpty(literal))
            {
                Source.Invoke().Generator.AddGenerationData(typeof(IClassGenericArgumentsConstraints), literal);
            }

            return _classInheritance;
        }
    }
}