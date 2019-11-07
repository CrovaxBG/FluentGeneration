using System;
using System.Linq;
using FluentGeneration.Interfaces.Class;
using FluentGeneration.Shared;

namespace FluentGeneration.Implementations.Class
{
    public class ClassGenericArgumentsConstraints<T> : IClassGenericArgumentsConstraints<T>
        where T : IGeneratedObject
    {
        private readonly IClassInheritance<T> _classInheritance;

        private Func<T> _source;
        public Func<T> Source
        {
            get => _source;
            set
            {
                _source = value;
                _classInheritance.Source = value;
            }
        }

        public ClassGenericArgumentsConstraints(IClassInheritance<T> classInheritance)
        {
            _classInheritance = classInheritance;
        }

        public IClassInheritance<T> WithGenericArgumentConstraint(params IGenericArgumentConstraint[] constraints)
        {
            if (constraints.Any())
            {
                Source.Invoke().Generator.AddGenerationData(typeof(IClassGenericArgumentsConstraints<>), constraints);
            }
            return _classInheritance;
        }

        public IClassInheritance<T> WithGenericArgumentConstraint(string literal)
        {
            if (!string.IsNullOrEmpty(literal))
            {
                Source.Invoke().Generator.AddGenerationData(typeof(IClassGenericArgumentsConstraints<>), literal);
            }

            return _classInheritance;
        }
    }
}