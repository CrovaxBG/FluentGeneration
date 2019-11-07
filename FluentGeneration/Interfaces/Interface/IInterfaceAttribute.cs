using System;
using FluentGeneration.Shared;

namespace FluentGeneration.Interfaces.Interface
{
    public interface IInterfaceAttribute<T> : IFluentLink<T>
        where T : IGeneratedObject
    {
        IInterfaceGenericArguments<T> WithAttributes(params Type[] attributeTypes);
        IInterfaceGenericArguments<T> WithAttributes(string literal);
    }
}