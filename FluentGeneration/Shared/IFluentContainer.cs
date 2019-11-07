using FluentGeneration.Interfaces.Class;
using FluentGeneration.Interfaces.Field;
using FluentGeneration.Interfaces.Interface;
using FluentGeneration.Interfaces.Method;
using FluentGeneration.Interfaces.Property;

namespace FluentGeneration.Shared
{
    public interface IFluentClass<T>
        where T : IGeneratedObject
    {
        IField<T> WithField();
        IProperty<T> WithProperty();
        IMethod<T> WithMethod();
    }

    public interface IFluentInterface<T>
        where T : IGeneratedObject
    {
        IProperty<T> WithProperty();
        IMethod<T> WithMethod();
    }

    public interface IFluentFile<T>
        where T : IGeneratedObject
    {
        IClass WithClass();
        IInterface WithInterface();
    }
}