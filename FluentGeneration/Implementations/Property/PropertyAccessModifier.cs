using System;
using FluentGeneration.Interfaces.Property;
using FluentGeneration.Shared;

namespace FluentGeneration.Implementations.Property
{
    public class PropertyAccessModifier<T> : IPropertyAccessModifier<T>
        where T : IGeneratedObject
    {
        private readonly IPropertyType<T> _propertyType;

        private Func<T> _source;
        public Func<T> Source
        {
            get => _source;
            set
            {
                _source = value;
                _propertyType.Source = value;
            }
        }

        public PropertyAccessModifier(IPropertyType<T> propertyType)
        {
            _propertyType = propertyType ?? throw new ArgumentNullException(nameof(propertyType));
        }

        public IPropertyType<T> WithAccessModifier(AccessModifiers accessModifier)
        {
            if (accessModifier != AccessModifiers.None)
            {
                Source.Invoke().Generator.AddGenerationData(typeof(IPropertyAccessModifier<>), accessModifier);
            }
            return _propertyType;
        }
    }
}