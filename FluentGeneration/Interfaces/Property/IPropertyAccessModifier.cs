using FluentGeneration.Shared;

namespace FluentGeneration.Interfaces.Property
{
    public interface IPropertyAccessModifier<out T>
    {
        IPropertyType<T> WithAccessModifier(AccessModifiers accessModifier);
    }
}