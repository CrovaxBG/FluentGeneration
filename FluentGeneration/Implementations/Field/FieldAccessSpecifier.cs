using System;
using FluentGeneration.Interfaces.Class;
using FluentGeneration.Interfaces.Field;
using FluentGeneration.Shared;

namespace FluentGeneration.Implementations.Field
{
    public class FieldAccessSpecifier : IFieldAccessSpecifier
    {
        private readonly IFieldAccessModifier _fieldAccessModifier;

        private Func<IField> _source;
        public Func<IField> Source
        {
            get => _source;
            set
            {
                _source = value;
                _fieldAccessModifier.Source = value;
            }
        }

        public FieldAccessSpecifier(IFieldAccessModifier fieldAccessModifier)
        {
            _fieldAccessModifier = fieldAccessModifier;
        }

        public IFieldAccessModifier WithAccessSpecifier(AccessSpecifier accessSpecifier)
        {
            if (accessSpecifier != AccessSpecifier.None)
            {
                Source.Invoke().Generator.AddGenerationData(typeof(IFieldAccessSpecifier), accessSpecifier);
            }
            return _fieldAccessModifier;
        }
    }
}