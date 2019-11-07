using System;
using FluentGeneration.Shared;

namespace FluentGeneration.Interfaces.Method
{
    public interface IMethodAttribute<T> : IFluentLink<T>
        where T : IGeneratedObject
    {
        IMethodGenericArguments<T> WithAttributes(params Type[] attributeTypes);
        IMethodGenericArguments<T> WithAttributes(string literal);
    }
}