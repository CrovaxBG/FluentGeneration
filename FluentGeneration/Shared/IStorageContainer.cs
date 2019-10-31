using FluentGeneration.Interfaces.Field;
using FluentGeneration.Interfaces.Method;
using FluentGeneration.Interfaces.Property;

namespace FluentGeneration.Shared
{
    public interface IStorageContainer<T>
        where T : IStorageContainer<T>, IGeneratedObject
    {
        void AddField(IField<T> field);
        void AddProperty(IProperty<T> property);
        void AddMethod(IMethod<T> method);
    }
}
