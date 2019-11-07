using System;
using FluentGeneration.Shared;

namespace FluentGeneration.Interfaces.Interface
{
    public interface IInterfaceAttribute : IFluentLink<IInterface>
    {
        IInterfaceGenericArguments WithAttributes(params Type[] attributeTypes);
        IInterfaceGenericArguments WithAttributes(string literal);
    }
}