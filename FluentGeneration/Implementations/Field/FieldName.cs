using System;
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
            _fieldAttribute = fieldAttribute ?? throw new ArgumentNullException(nameof(fieldAttribute));
        }

        public IFieldAttribute WithName(string name)
        {
            if(name == null) { throw new ArgumentNullException(nameof(name)); }

            Source.Invoke().Generator.AddGenerationData(typeof(IFieldName), name);
            return _fieldAttribute;
        }
    }
}