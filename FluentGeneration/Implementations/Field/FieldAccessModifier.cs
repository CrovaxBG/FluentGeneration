using System;
using FluentGeneration.Interfaces.Field;
using FluentGeneration.Shared;

namespace FluentGeneration.Implementations.Field
{
    public class FieldAccessModifier<T> : IFieldAccessModifier<T>
        where T : IGeneratedObject
    {
        private readonly IFieldType<T> _fieldType;

        private Func<T> _source;
        public Func<T> Source
        {
            get => _source;
            set
            {
                _source = value;
                _fieldType.Source = value;
            }
        }

        public FieldAccessModifier(IFieldType<T> fieldType)
        {
            _fieldType = fieldType;
        }

        public IFieldType<T> WithAccessModifier(AccessModifiers accessModifiers)
        {
            Source.Invoke().Generator.AddGenerationData(typeof(IFieldAccessModifier<>), accessModifiers);
            return _fieldType;
        }
    }
}