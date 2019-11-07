using System;
using FluentGeneration.Interfaces.Class;
using FluentGeneration.Interfaces.Field;

namespace FluentGeneration.Implementations.Field
{
    public class FieldType : IFieldType
    {
        private readonly IFieldName _fieldName;

        private Func<IField> _source;
        public Func<IField> Source
        {
            get => _source;
            set
            {
                _source = value;
                _fieldName.Source = value;
            }
        }

        public FieldType(IFieldName fieldName)
        {
            _fieldName = fieldName;
        }

        public IFieldName WithType(Type type)
        {
            Source.Invoke().Generator.AddGenerationData(typeof(IFieldType), type);
            return _fieldName;
        }

        public IFieldName WithType(string literal)
        {
            Source.Invoke().Generator.AddGenerationData(typeof(IFieldType), literal);
            return _fieldName;
        }
    }
}