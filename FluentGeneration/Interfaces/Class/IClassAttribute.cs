using System;
using FluentGeneration.Shared;

namespace FluentGeneration.Interfaces.Class
{
    public interface IClassAttribute<T> : IFluentLink<T>
        where T : IGeneratedObject
    {
        IClassGenericArguments<T> WithAttributes(params Type[] attributeTypes);        
        IClassGenericArguments<T> WithAttributes(string literal);
    }
}