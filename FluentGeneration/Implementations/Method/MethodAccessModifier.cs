using System;
using FluentGeneration.Interfaces.Method;
using FluentGeneration.Shared;

namespace FluentGeneration.Implementations.Method
{
    public class MethodAccessModifier<T> : IMethodAccessModifier<T>
        where T : IGeneratedObject
    {
        private readonly IMethodType<T> _methodType;

        private Func<T> _source;
        public Func<T> Source
        {
            get => _source;
            set
            {
                _source = value;
                _methodType.Source = value;
            }
        }

        public MethodAccessModifier(IMethodType<T> methodType)
        {
            _methodType = methodType ?? throw new ArgumentNullException(nameof(methodType));
        }

        public IMethodType<T> WithAccessModifier(AccessModifiers accessModifier)
        {
            if (accessModifier != AccessModifiers.None)
            {
                Source.Invoke().Generator.AddGenerationData(typeof(IMethodAccessModifier<>), accessModifier);
            }
            return _methodType;
        }
    }
}