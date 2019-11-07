using System;
using FluentGeneration.Interfaces.Property;
using FluentGeneration.Shared;

namespace FluentGeneration.Implementations.Property
{
    public class PropertyType<T> : IPropertyType<T>
        where T : IGeneratedObject
    {
        private readonly IPropertyName<T> _propertyName;

        private Func<T> _source;
        public Func<T> Source
        {
            get => _source;
            set
            {
                _source = value;
                _propertyName.Source = value;
            }
        }

        public PropertyType(IPropertyName<T> propertyName)
        {
            _propertyName = propertyName ?? throw new ArgumentNullException(nameof(propertyName));
        }

        public IPropertyName<T> WithType(Type type)
        {
            if(type == null) { throw new ArgumentNullException(nameof(type)); }

            Source.Invoke().Generator.AddGenerationData(typeof(IPropertyType<>), type);
            return _propertyName;
        }

        public IPropertyName<T> WithType(string literal)
        {
            if (literal == null) { throw new ArgumentNullException(nameof(literal)); }

            Source.Invoke().Generator.AddGenerationData(typeof(IPropertyType<>), literal);
            return _propertyName;
        }
    }
}