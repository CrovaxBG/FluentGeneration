using System;
using FluentGeneration.Interfaces.Field;
using FluentGeneration.Shared;

namespace FluentGeneration.Implementations.Field
{
    public class FieldType<T> : IFieldType<T>
        where T : IGeneratedObject
    {
        private readonly IFieldName<T> _fieldName;

        private Func<T> _source;
        public Func<T> Source
        {
            get => _source;
            set
            {
                _source = value;
                _fieldName.Source = value;
            }
        }

        public FieldType(IFieldName<T> fieldName)
        {
            _fieldName = fieldName;
        }

        public IFieldName<T> WithType(Type type)
        {
            Source.Invoke().Generator.AddGenerationData(typeof(IFieldType<>), type);
            return _fieldName;
        }
    }
}