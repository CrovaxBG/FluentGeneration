using System;
using FluentGeneration.Shared;

namespace FluentGeneration.Interfaces.Method
{
    public interface IMethodType<T> : IFluentLink<T>
        where T : IGeneratedObject
    {
        IMethodName<T> WithType(Type type);
    }
}