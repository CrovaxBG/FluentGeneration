using System;
using FluentGeneration.Interfaces.Class;
using FluentGeneration.Interfaces.Field;

namespace FluentGeneration.Implementations.Field
{
    public class FieldValue : IFieldValue
    {
        public Func<IField> Source { get; set; }

        public IField WithNoValue()
        {
            return Source.Invoke();
        }

        public IField WithValue(object value)
        {
            var source = Source.Invoke();
            source.Generator.AddGenerationData(typeof(IFieldValue), value);
            return source;
        }
    }
}