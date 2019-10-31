using System;
using FluentGeneration.Interfaces.Field;
using FluentGeneration.Shared;

namespace FluentGeneration.Implementations.Field
{
    public class FieldAttribute<T> : IFieldAttribute<T>
        where T : IGeneratedObject
    {
        private readonly IFieldValue<T> _fieldValue;

        private Func<T> _source;
        public Func<T> Source
        {
            get => _source;
            set
            {
                _source = value;
                _fieldValue.Source = value;
            }
        }

        public FieldAttribute(IFieldValue<T> fieldValue)
        {
            _fieldValue = fieldValue;
        }

        public IFieldValue<T> WithAttributes(params Type[] attributeTypes)
        {
            Source.Invoke().Generator.AddGenerationData(typeof(IFieldAttribute<>), attributeTypes);
            return _fieldValue;
        }
    }
}