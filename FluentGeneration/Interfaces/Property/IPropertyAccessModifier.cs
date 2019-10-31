using FluentGeneration.Shared;

namespace FluentGeneration.Interfaces.Property
{
    public interface IPropertyAccessModifier<T> : IFluentLink<T>
        where T : IGeneratedObject
    {
        IPropertyType<T> WithAccessModifier(AccessModifiers accessModifier);
    }
}