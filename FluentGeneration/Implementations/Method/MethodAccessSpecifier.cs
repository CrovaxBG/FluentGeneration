using System;
using FluentGeneration.Interfaces.Method;
using FluentGeneration.Shared;

namespace FluentGeneration.Implementations.Method
{
    public class MethodAccessSpecifier<T> : IMethodAccessSpecifier<T>
        where T : IGeneratedObject
    {
        private readonly IMethodAccessModifier<T> _methodAccessModifier;

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

        public MethodAccessSpecifier(IMethodAccessModifier<T> methodAccessModifier)
        {
            _methodAccessModifier = methodAccessModifier;
        }

        public IMethodAccessModifier<T> WithAccessSpecifier(AccessSpecifier accessSpecifier)
        {
            if (accessSpecifier != AccessSpecifier.None)
            {
                Source.Invoke().Generator.AddGenerationData(typeof(IMethodAccessSpecifier<>), accessSpecifier);
            }
            return _methodAccessModifier;
        }
    }
}