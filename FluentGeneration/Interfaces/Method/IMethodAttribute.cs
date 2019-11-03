using System;
using FluentGeneration.Shared;

namespace FluentGeneration.Interfaces.Method
{
    public interface IMethodAttribute<T> : IFluentLink<T>
        where T : IGeneratedObject
    {
        IMethodParameters<T> WithAttributes(params Type[] attributeType);
    }
}