using System;
using FluentGeneration.Shared;

namespace FluentGeneration.Interfaces.Class
{
    public interface IClassAttribute : IFluentLink<IClass>
    {
        IClassGenericArguments WithAttributes(params Type[] attributeTypes);        
        IClassGenericArguments WithAttributes(string literal);
    }
}