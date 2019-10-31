using FluentGeneration.Interfaces.Field;
using FluentGeneration.Interfaces.Method;
using FluentGeneration.Interfaces.Property;

namespace FluentGeneration.Shared
{
    public interface IFluentContainer<T>
        where T : IStorageContainer<T>, IGeneratedObject
    {
        IProperty<T> WithProperty();
        IField<T> WithField();
        IMethod<T> WithMethod();
    }
}