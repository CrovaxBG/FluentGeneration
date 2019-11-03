using System;
using FluentGeneration.Interfaces.Method;
using FluentGeneration.Shared;

namespace FluentGeneration.Implementations.Method
{
    public class MethodParameters<T> : IMethodParameters<T>
        where T : IGeneratedObject
    {
        private readonly IMethodBody<T> _methodBody;

        private Func<T> _source;
        public Func<T> Source
        {
            get => _source;
            set
            {
                _source = value;
                _methodBody.Source = value;
            }
        }

        public MethodParameters(IMethodBody<T> methodBody)
        {
            _methodBody = methodBody;
        }

        public IMethodBody<T> WithParameters(params IParameter[] parameterType)
        {
            Source.Invoke().Generator.AddGenerationData(typeof(IMethodParameters<>), parameterType);
            return _methodBody;
        }
    }
}