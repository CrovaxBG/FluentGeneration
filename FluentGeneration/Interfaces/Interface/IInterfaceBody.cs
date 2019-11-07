using FluentGeneration.Interfaces.Method;
using FluentGeneration.Interfaces.Property;
using FluentGeneration.Shared;

namespace FluentGeneration.Interfaces.Interface
{
    public interface IInterfaceBody<T> : IGeneratedObject, IFluentLink<T>, IEndable<T>
        where T : IGeneratedObject
    {
        IProperty<IInterfaceBody<T>> WithProperty();
        IMethod<IInterfaceBody<T>> WithMethod();
    }
}