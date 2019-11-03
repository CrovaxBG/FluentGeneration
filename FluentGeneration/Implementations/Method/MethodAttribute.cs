using System;
using FluentGeneration.Interfaces.Method;
using FluentGeneration.Shared;

namespace FluentGeneration.Implementations.Method
{
    public class MethodAttribute<T> : IMethodAttribute<T>
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

        public MethodAttribute(IMethodParameters<T> methodParameters)
        {
            _methodParameters = methodParameters;
        }

        public IMethodParameters<T> WithAttributes(params Type[] attributeType)
        {
            Source.Invoke().Generator.AddGenerationData(typeof(IMethodAttribute<>), attributeType);
            return _methodParameters;
        }
    }
}