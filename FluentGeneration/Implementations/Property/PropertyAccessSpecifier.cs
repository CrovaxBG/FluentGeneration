using System;
using FluentGeneration.Interfaces.Property;
using FluentGeneration.Shared;

namespace FluentGeneration.Implementations.Property
{
    public class PropertyAccessSpecifier<T> : IPropertyAccessSpecifier<T>
        where T : IGeneratedObject
    {
        private readonly IPropertyAccessModifier<T> _propertyAccessModifier;

        private Func<T> _source;
        public Func<T> Source
        {
            get => _source;
            set
            {
                _source = value;
                _propertyAccessModifier.Source = value;
            }
        }

        public PropertyAccessSpecifier(IPropertyAccessModifier<T> propertyAccessModifier)
        {
            _propertyAccessModifier = propertyAccessModifier;
        }

        public IPropertyAccessModifier<T> WithAccessSpecifier(AccessSpecifier accessSpecifier)
        {
            if (accessSpecifier != AccessSpecifier.None)
            {
                Source.Invoke().Generator.AddGenerationData(typeof(IPropertyAccessSpecifier<>), accessSpecifier);
            }
            return _propertyAccessModifier;
        }
    }
}
