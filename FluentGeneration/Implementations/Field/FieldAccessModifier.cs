using System;
using FluentGeneration.Interfaces.Field;
using FluentGeneration.Shared;

namespace FluentGeneration.Implementations.Field
{
    public class FieldAccessModifier : IFieldAccessModifier
    {
        private readonly IFieldType _fieldType;

        private Func<IField> _source;
        public Func<IField> Source
        {
            get => _source;
            set
            {
                _source = value;
                _fieldType.Source = value;
            }
        }

        public FieldAccessModifier(IFieldType fieldType)
        {
            _fieldType = fieldType ?? throw new ArgumentNullException(nameof(fieldType));
        }

        public IFieldType WithAccessModifier(AccessModifiers accessModifiers)
        {
            if (accessModifiers != AccessModifiers.None)
            {
                Source.Invoke().Generator.AddGenerationData(typeof(IFieldAccessModifier), accessModifiers);
            }
            return _fieldType;
        }
    }
}