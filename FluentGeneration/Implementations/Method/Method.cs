using System;
using FluentGeneration.Generators;
using FluentGeneration.Interfaces.Method;
using FluentGeneration.Shared;

namespace FluentGeneration.Implementations.Method
{
    public class Method<T> : IMethod<T>
        where T : IGeneratedObject
    {
        public IGenerator Generator { get; }
        public string Data { get; private set; }
        public Func<T> Source { get; set; }

        private readonly IMethodAccessSpecifier<IMethod<T>> _accessSpecifier;

        public Method(IGenerator generator, IMethodAccessSpecifier<IMethod<T>> accessSpecifier)
        {
            Generator = generator ?? throw new ArgumentNullException(nameof(generator));
            _accessSpecifier = accessSpecifier ?? throw new ArgumentNullException(nameof(accessSpecifier));
            _accessSpecifier.Source = () => this;
        }

        public IMethodAccessSpecifier<IMethod<T>> Begin()
        {
            return _accessSpecifier;
        }

        public T End()
        {
            Data = Generator.Generate(PatternConfig.MethodPattern);
            Source.Invoke().Generator.AddGenerationData(typeof(IMethod<>), Data);
            return Source.Invoke();
        }
    }
}