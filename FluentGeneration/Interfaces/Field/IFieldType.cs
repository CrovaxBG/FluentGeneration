using System;
using FluentGeneration.Shared;

namespace FluentGeneration.Interfaces.Field
{
    public interface IFieldType<T> : IFluentLink<T>
        where T : IGeneratedObject
    {
        IFieldName<T> WithType(Type type);
        IFieldName<T> WithType(string literal);
    }
}