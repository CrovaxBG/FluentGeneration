using System;
using FluentGeneration.Shared;

namespace FluentGeneration.Interfaces.Field
{
    public interface IFieldAttribute<T> : IFluentLink<T>
        where T : IGeneratedObject
    {
        IFieldValue<T> WithAttributes(params Type[] attributeTypes);
        IFieldValue<T> WithAttributes(string literal);
    }
}