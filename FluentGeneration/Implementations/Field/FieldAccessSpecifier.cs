using System;
using FluentGeneration.Interfaces.Field;
using FluentGeneration.Shared;

namespace FluentGeneration.Implementations.Field
{
    public class FieldAccessSpecifier<T> : IFieldAccessSpecifier<T>
        where T : IGeneratedObject
    {
        private readonly IFieldAccessModifier<T> _fieldAccessModifier;

        private Func<T> _source;
        public Func<T> Source
        {
            get => _source;
            set
            {
                _source = value;
                _fieldAccessModifier.Source = value;
            }
        }

        public FieldAccessSpecifier(IFieldAccessModifier<T> fieldAccessModifier)
        {
            _fieldAccessModifier = fieldAccessModifier;
        }

        public IFieldAccessModifier<T> WithAccessSpecifier(AccessSpecifier accessSpecifier)
        {
            if (accessSpecifier != AccessSpecifier.None)
            {
                Source.Invoke().Generator.AddGenerationData(typeof(IFieldAccessSpecifier<>), accessSpecifier);
            }
            return _fieldAccessModifier;
        }
    }
}