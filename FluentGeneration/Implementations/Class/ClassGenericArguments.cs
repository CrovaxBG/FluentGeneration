using System;
using System.Linq;
using FluentGeneration.Interfaces.Class;
using FluentGeneration.Shared;

namespace FluentGeneration.Implementations.Class
{
    public class ClassGenericArguments : IClassGenericArguments
    {
        private readonly IClassGenericArgumentsConstraints _classGenericArgumentsConstraints;

        private Func<IClass> _source;
        public Func<IClass> Source
        {
            get => _source;
            set
            {
                _source = value;
                _classGenericArgumentsConstraints.Source = value;
            }
        }

        public ClassGenericArguments(IClassGenericArgumentsConstraints classGenericArgumentsConstraints)
        {
            _classGenericArgumentsConstraints = classGenericArgumentsConstraints;
        }

        public IClassGenericArgumentsConstraints WithGenericArguments(params IGenericArgument[] arguments)
        {
            if (arguments.Any())
            {
                Source.Invoke().Generator.AddGenerationData(typeof(IClassGenericArguments), arguments);
            }
            return _classGenericArgumentsConstraints;
        }
    }
}