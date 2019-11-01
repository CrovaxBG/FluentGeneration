using System;
using FluentGeneration.Interfaces.Property;
using FluentGeneration.Shared;

namespace FluentGeneration.Implementations.Property
{
    public class PropertyAttribute<T> : IPropertyAttribute<T>
        where T : IGeneratedObject
    {
        private readonly IGetAccessSpecifier<T> _getAccessSpecifier;

        private Func<T> _source;
        public Func<T> Source
        {
            get => _source;
            set
            {
                _source = value;
                _getAccessSpecifier.Source = value;
            }
        }

        public PropertyAttribute(IGetAccessSpecifier<T> getAccessSpecifier)
        {
            _getAccessSpecifier = getAccessSpecifier;
        }

        public IGetAccessSpecifier<T> WithAttributes(params Type[] attributeTypes)
        {
            Source.Invoke().Generator.AddGenerationData(typeof(IPropertyAttribute<>), attributeTypes);
            return _getAccessSpecifier;
        }
    }
}