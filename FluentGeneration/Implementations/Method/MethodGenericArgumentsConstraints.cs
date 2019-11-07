using System;
using System.Linq;
using FluentGeneration.Interfaces.Method;
using FluentGeneration.Shared;

namespace FluentGeneration.Implementations.Method
{
    public class MethodGenericArgumentsConstraints<T> : IMethodGenericArgumentsConstraints<T>
        where T : IGeneratedObject
    {
        private readonly IMethodParameters<T> _methodParameters;

        private Func<T> _source;
        public Func<T> Source
        {
            get => _source;
            set
            {
                _source = value;
                _methodParameters.Source = value;
            }
        }

        public MethodGenericArgumentsConstraints(IMethodParameters<T> methodParameters)
        {
            _methodParameters = methodParameters ?? throw new ArgumentNullException(nameof(methodParameters));
        }

        public IMethodParameters<T> WithGenericArgumentConstraint(params IGenericArgumentConstraint[] constraints)
        {
            if (constraints != null && constraints.Any())
            {
                Source.Invoke().Generator.AddGenerationData(typeof(IMethodGenericArgumentsConstraints<>), constraints);
            }

            return _methodParameters;
        }

        public IMethodParameters<T> WithGenericArgumentConstraint(string literal)
        {
            if (literal == null) { throw new ArgumentNullException(nameof(literal)); }
            
            Source.Invoke().Generator.AddGenerationData(typeof(IMethodGenericArgumentsConstraints<>), literal);
            return _methodParameters;
        }
    }
}