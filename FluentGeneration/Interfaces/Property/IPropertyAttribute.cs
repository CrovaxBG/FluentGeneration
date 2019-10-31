using System;
using FluentGeneration.Shared;

namespace FluentGeneration.Interfaces.Property
{
    public interface IPropertyAttribute<T> : IFluentLink<T>
        where T : IGeneratedObject
    {
        IGetAccessSpecifier<T> WithAttributes(params Type[] attributeType);
    }
}