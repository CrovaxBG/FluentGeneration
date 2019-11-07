using FluentGeneration.Interfaces.Field;
using FluentGeneration.Interfaces.Method;
using FluentGeneration.Interfaces.Property;
using FluentGeneration.Shared;

namespace FluentGeneration.Interfaces.Class
{
    public interface IClassBody<T> : IGeneratedObject, IFluentLink<T>, IEndable<T>
        where T : IGeneratedObject
    {
        IField<IClassBody<T>> WithField();
        IProperty<IClassBody<T>> WithProperty();
        IMethod<IClassBody<T>> WithMethod();
    }
}