using System;
using FluentGeneration.Interfaces.Property;
using FluentGeneration.Shared;

namespace FluentGeneration.Implementations.Property
{
    public class PropertyName<T> : IPropertyName<T>
        where T : IGeneratedObject
    {
        private readonly IPropertyAttribute<T> _propertyAttribute;

        private Func<T> _source;
        public Func<T> Source
        {
            get => _source;
            set
            {
                _source = value;
                _propertyAttribute.Source = value;
            }
        }

        public PropertyName(IPropertyAttribute<T> propertyAttribute)
        {
            _propertyAttribute = propertyAttribute ?? throw new ArgumentNullException(nameof(propertyAttribute));
        }

        public IPropertyAttribute<T> WithName(string name)
        {
            if(name == null) { throw new ArgumentNullException(nameof(name)); }

            Source.Invoke().Generator.AddGenerationData(typeof(IPropertyName<>), name);
            return _propertyAttribute;
        }
    }
}