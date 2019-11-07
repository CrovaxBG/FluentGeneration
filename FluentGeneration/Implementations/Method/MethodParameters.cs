using System;
using System.Linq;
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
            _methodBody = methodBody ?? throw new ArgumentNullException(nameof(methodBody));
        }

        public IMethodBody<T> WithParameters(params IParameter[] parameterTypes)
        {
            if (parameterTypes != null && parameterTypes.Any())
            {
                Source.Invoke().Generator.AddGenerationData(typeof(IMethodParameters<>), parameterTypes);
            }

            return _methodBody;
        }

        public IMethodBody<T> WithParameters(string literal)
        {
            if (literal == null) { throw new ArgumentNullException(nameof(literal)); }

            Source.Invoke().Generator.AddGenerationData(typeof(IMethodParameters<>), literal);
            return _methodBody;
        }
    }
}