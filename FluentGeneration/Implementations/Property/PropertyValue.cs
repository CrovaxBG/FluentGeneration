using System;
using FluentGeneration.Interfaces.Property;
using FluentGeneration.Shared;

namespace FluentGeneration.Implementations.Property
{
    public class PropertyValue<T> : IPropertyValue<T>
        where T : IGeneratedObject
    {
        public Func<T> Source { get; set; }

        public T WithNoValue()
        {
            return Source.Invoke();
        }

        public T WithPropertyValue(string value)
        {
            var source = Source.Invoke();
            source.Generator.AddGenerationData(typeof(IPropertyValue<>), value);
            return source;
        }
    }
}