using FluentGeneration.Shared;

namespace FluentGeneration.Interfaces.Property
{
    public interface IProperty<out T> : IGeneratedObject, IEndable<T>,
        IPropertyAccessSpecifier<IProperty<T>>, IPropertyAccessModifier<IProperty<T>>,
        IPropertyType<IProperty<T>>, IPropertyName<IProperty<T>>, IPropertyAttribute<IProperty<T>>,
        IGetBody<IProperty<T>>, ISetBody<IProperty<T>>, IPropertyValue<IProperty<T>>
    {

    }
}
