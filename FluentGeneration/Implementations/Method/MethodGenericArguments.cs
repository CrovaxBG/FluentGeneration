using System;
using System.Linq;
using FluentGeneration.Interfaces.Method;
using FluentGeneration.Shared;

namespace FluentGeneration.Implementations.Method
{
    public class MethodGenericArguments<T> : IMethodGenericArguments<T>
        where T : IGeneratedObject
    {
        private readonly IMethodGenericArgumentsConstraints<T> _methodGenericArgumentsConstraints;

        private Func<T> _source;
        public Func<T> Source
        {
            get => _source;
            set
            {
                _source = value;
                _methodGenericArgumentsConstraints.Source = value;
            }
        }

        public MethodGenericArguments(IMethodGenericArgumentsConstraints<T> methodGenericArgumentsConstraints)
        {
            _methodGenericArgumentsConstraints = methodGenericArgumentsConstraints;
        }

        public IMethodGenericArgumentsConstraints<T> WithGenericArguments(params IGenericArgument[] arguments)
        {
            if (arguments.Any())
            {
                Source.Invoke().Generator.AddGenerationData(typeof(IMethodGenericArguments<>), arguments);
            }

            return _methodGenericArgumentsConstraints;
        }

        public IMethodGenericArgumentsConstraints<T> WithGenericArguments(string literal)
        {
            if (!string.IsNullOrEmpty(literal))
            {
                Source.Invoke().Generator.AddGenerationData(typeof(IMethodGenericArguments<>), literal);
            }

            return _methodGenericArgumentsConstraints;
        }
    }
}