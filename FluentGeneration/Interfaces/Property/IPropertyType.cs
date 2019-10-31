using System;
using FluentGeneration.Shared;

namespace FluentGeneration.Interfaces.Property
{
    public interface IPropertyType<T> : IFluentLink<T>
        where T : IGeneratedObject
    {
        IPropertyName<T> WithType(Type type);
    }
}