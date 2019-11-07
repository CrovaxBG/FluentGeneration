using System;
using FluentGeneration.Shared;

namespace FluentGeneration.Interfaces.Class
{
    public interface IClassAttribute<T> : IFluentLink<T>
        where T : IGeneratedObject
    {
        IClassGenericArguments<T> WithClassAttributes(params Type[] attributeTypes);        
        IClassGenericArguments<T> WithClassAttributes(string literal);
    }
}