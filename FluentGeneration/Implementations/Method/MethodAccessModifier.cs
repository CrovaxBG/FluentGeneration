using System;
using FluentGeneration.Interfaces.Method;
using FluentGeneration.Shared;

namespace FluentGeneration.Implementations.Method
{
    public class MethodAccessModifier<T> : IMethodAccessModifier<T>
        where T : IGeneratedObject
    {
        private readonly IMethodType<T> _methodAccessModifier;

        private Func<T> _source;
        public Func<T> Source
        {
            get => _source;
            set
            {
                _source = value;
                _methodAccessModifier.Source = value;
            }
        }

        public MethodAccessModifier(IMethodType<T> methodAccessModifier)
        {
            _methodAccessModifier = methodAccessModifier;
        }

        public IMethodType<T> WithAccessModifier(AccessModifiers accessModifier)
        {
            if (accessModifier != AccessModifiers.None)
            {
                Source.Invoke().Generator.AddGenerationData(typeof(IMethodAccessModifier<>), accessModifier);
            }
            return _methodAccessModifier;
        }
    }
}