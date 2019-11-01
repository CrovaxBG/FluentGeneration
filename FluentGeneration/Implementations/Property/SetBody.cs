using System;
using FluentGeneration.Interfaces.Property;
using FluentGeneration.Shared;

namespace FluentGeneration.Implementations.Property
{
    public class SetBody<T> : ISetBody<T>
        where T : IGeneratedObject
    {
        private readonly IPropertyValue<T> _propertyValue;

        private Func<T> _source;
        public Func<T> Source
        {
            get => _source;
            set
            {
                _source = value;
                _propertyValue.Source = value;
            }
        }

        public SetBody(IPropertyValue<T> propertyValue)
        {
            _propertyValue = propertyValue;
        }

        public IPropertyValue<T> AutoSet()
        {
            Source.Invoke().Generator.AddGenerationData(typeof(ISetBody<>), new BodyData { IsAuto = true });
            return _propertyValue;
        }

        public IPropertyValue<T> WithSetBody(string body)
        {
            Source.Invoke().Generator.AddGenerationData(typeof(ISetBody<>), new BodyData { IsAuto = false, Body = body });
            return _propertyValue;
        }
    }
}