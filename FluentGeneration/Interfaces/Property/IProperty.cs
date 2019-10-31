using FluentGeneration.Shared;

namespace FluentGeneration.Interfaces.Property
{
    public interface IProperty<T> :
        IGeneratedObject, IFluentLink<T>,
        IBeginable<IPropertyAccessSpecifier<IProperty<T>>>, IEndable<T>
        where T : IGeneratedObject
    {

    }
}
