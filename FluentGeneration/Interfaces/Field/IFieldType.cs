using System;
using FluentGeneration.Interfaces.Class;
using FluentGeneration.Shared;

namespace FluentGeneration.Interfaces.Field
{
    public interface IFieldType : IFluentLink<IField>
    {
        IFieldName WithType(Type type);
        IFieldName WithType(string literal);
    }
}