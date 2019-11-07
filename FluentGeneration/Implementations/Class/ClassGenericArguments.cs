using System;
using System.Linq;
using FluentGeneration.Interfaces.Class;
using FluentGeneration.Shared;

namespace FluentGeneration.Implementations.Class
{
    public class ClassGenericArguments<T> : IClassGenericArguments<T>
        where T : IGeneratedObject
    {
        private readonly IClassGenericArgumentsConstraints<T> _classGenericArgumentsConstraints;

        private Func<T> _source;
        public Func<T> Source
        {
            get => _source;
            set
            {
                _source = value;
                _classGenericArgumentsConstraints.Source = value;
            }
        }

        public ClassGenericArguments(IClassGenericArgumentsConstraints<T> classGenericArgumentsConstraints)
        {
            _classGenericArgumentsConstraints = classGenericArgumentsConstraints;
        }

        public IClassGenericArgumentsConstraints<T> WithGenericArguments(params IGenericArgument[] arguments)
        {
            if (arguments.Any())
            {
                Source.Invoke().Generator.AddGenerationData(typeof(IClassGenericArguments<>), arguments);
            }
            return _classGenericArgumentsConstraints;
        }
    }
}