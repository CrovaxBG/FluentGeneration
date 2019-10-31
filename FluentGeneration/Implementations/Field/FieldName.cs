using System;
using FluentGeneration.Interfaces.Field;
using FluentGeneration.Shared;

namespace FluentGeneration.Implementations.Field
{
    public class FieldName<T> : IFieldName<T>
        where T : IGeneratedObject
    {
        private readonly IFieldAttribute<T> _fieldAttribute;

        private Func<T> _source;
        public Func<T> Source
        {
            get => _source;
            set
            {
                _source = value;
                _fieldAttribute.Source = value;
            }
        }

        public FieldName(IFieldAttribute<T> fieldAttribute)
        {
            _fieldAttribute = fieldAttribute;
        }

        public IFieldAttribute<T> WithName(string name)
        {
            Source.Invoke().Generator.AddGenerationData(typeof(IFieldName<>), name);
            return _fieldAttribute;
        }
    }
}