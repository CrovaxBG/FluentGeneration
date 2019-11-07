using System;
using FluentGeneration.Interfaces.Method;
using FluentGeneration.Shared;

namespace FluentGeneration.Implementations.Method
{
    public class MethodType<T> : IMethodType<T>
        where T : IGeneratedObject
    {
        private readonly IMethodName<T> _methodName;

        private Func<T> _source;
        public Func<T> Source
        {
            get => _source;
            set
            {
                _source = value;
                _methodName.Source = value;
            }
        }

        public MethodType(IMethodName<T> methodName)
        {
            _methodName = methodName;
        }

        public IMethodName<T> WithType(Type type)
        {
            Source.Invoke().Generator.AddGenerationData(typeof(IMethodType<>), type);
            return _methodName;
        }

        public IMethodName<T> WithType(string literal)
        {
            Source.Invoke().Generator.AddGenerationData(typeof(IMethodType<>), literal);
            return _methodName;
        }
    }
}