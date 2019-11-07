using FluentGeneration.Interfaces.Field;
using FluentGeneration.Interfaces.Method;
using FluentGeneration.Interfaces.Property;
using FluentGeneration.Shared;

namespace FluentGeneration.Interfaces.Class
{
    public interface IClassBody : IGeneratedObject, IFluentLink<IClass>, IEndable<IClass>
    {
        IField WithField();
        IProperty<IClassBody> WithProperty();
        IMethod<IClassBody> WithMethod();
    }
}