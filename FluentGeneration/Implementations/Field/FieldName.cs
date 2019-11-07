using System;
using FluentGeneration.Interfaces.Class;
using FluentGeneration.Interfaces.Field;

namespace FluentGeneration.Implementations.Field
{
    public class FieldName : IFieldName
    {
        private readonly IFieldAttribute _fieldAttribute;

        private Func<IField> _source;
        public Func<IField> Source
        {
            get => _source;
            set
            {
                _source = value;
                _fieldAttribute.Source = value;
            }
        }

        public FieldName(IFieldAttribute fieldAttribute)
        {
            _fieldAttribute = fieldAttribute;
        }

        public IFieldAttribute WithName(string name)
        {
            Source.Invoke().Generator.AddGenerationData(typeof(IFieldName), name);
            return _fieldAttribute;
        }
    }
}