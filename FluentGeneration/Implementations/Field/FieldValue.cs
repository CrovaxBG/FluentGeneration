using System;
using FluentGeneration.Interfaces.Field;
using FluentGeneration.Shared;

namespace FluentGeneration.Implementations.Field
{
    public class FieldValue<T> : IFieldValue<T>
        where T : IGeneratedObject
    {
        public Func<T> Source { get; set; }

        public T WithNoValue()
        {
            return Source.Invoke();
        }

        public T WithValue(object value)
        {
            Source.Invoke().Generator.AddGenerationData(typeof(IFieldValue<>), value);
            return Source.Invoke();
        }
    }
}