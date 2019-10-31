using System;

namespace FluentGeneration.Interfaces.Method
{
    public interface IMethodAttribute<out T>
    {
        IMethodParameters<T> WithAttributes(params Type[] attributeType);
    }
}