using System;

namespace FluentGeneration.Interfaces.Property
{
    public interface IPropertyAttribute<out T>
    {
        IGetAccessSpecifier<T> WithAttributes(params Type[] attributeType);
    }
}