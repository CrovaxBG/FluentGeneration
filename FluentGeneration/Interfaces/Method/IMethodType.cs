using System;

namespace FluentGeneration.Interfaces.Method
{
    public interface IMethodType<out T>
    {
        IMethodName<T> WithType(Type type);
    }
}