using System;
using System.Linq;
using FluentGeneration.Interfaces.Class;
using FluentGeneration.Interfaces.Field;

namespace FluentGeneration.Implementations.Field
{
    public class FieldAttribute : IFieldAttribute
    {
        private readonly IFieldValue _fieldValue;

        private Func<IField> _source;
        public Func<IField> Source
        {
            get => _source;
            set
            {
                _source = value;
                _fieldValue.Source = value;
            }
        }

        public FieldAttribute(IFieldValue fieldValue)
        {
            _fieldValue = fieldValue;
        }

        public IFieldValue WithAttributes(params Type[] attributeTypes)
        {
            if (attributeTypes.Any())
            {
                Source.Invoke().Generator.AddGenerationData(typeof(IFieldAttribute), attributeTypes);
            }

            return _fieldValue;
        }

        public IFieldValue WithAttributes(string literal)
        {
            if (!string.IsNullOrEmpty(literal))
            {
                Source.Invoke().Generator.AddGenerationData(typeof(IFieldAttribute), literal);
            }

            return _fieldValue;
        }
    }
}