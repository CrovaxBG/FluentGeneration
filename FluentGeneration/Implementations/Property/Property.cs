using System;
using FluentGeneration.Generators;
using FluentGeneration.Interfaces.Property;
using FluentGeneration.Shared;

namespace FluentGeneration.Implementations.Property
{
    public class Property<T> : IProperty<T>
        where T : IGeneratedObject
    {
        public IGenerator Generator { get; }
        public string Data { get; private set; }
        public Func<T> Source { get; set; }

        private readonly IPropertyAccessSpecifier<IProperty<T>> _accessSpecifier;

        public Property(IGenerator generator, IPropertyAccessSpecifier<IProperty<T>> accessSpecifier)
        {
            Generator = generator ?? throw new ArgumentNullException(nameof(generator));
            _accessSpecifier = accessSpecifier ?? throw new ArgumentNullException(nameof(accessSpecifier));
            _accessSpecifier.Source = () => this;
        }

        public IPropertyAccessSpecifier<IProperty<T>> Begin()
        {
            return _accessSpecifier;
        }

        public T End()
        {
            Data = Generator.Generate(PatternConfig.PropertyPattern);
            Source.Invoke().Generator.AddGenerationData(typeof(IProperty<>), Data);
            return Source.Invoke();
        }
    }
}