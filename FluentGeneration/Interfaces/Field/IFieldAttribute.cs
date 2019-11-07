using System;
using FluentGeneration.Interfaces.Class;
using FluentGeneration.Shared;

namespace FluentGeneration.Interfaces.Field
{
    public interface IFieldAttribute : IFluentLink<IField>
    {
        IFieldValue WithAttributes(params Type[] attributeTypes);
        IFieldValue WithAttributes(string literal);
    }
}