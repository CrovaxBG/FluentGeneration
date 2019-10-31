using System;

namespace FluentGeneration.Interfaces.Property
{
    public interface IPropertyType<out T>
    {
        IPropertyName<T> WithType(Type type);
    }
}