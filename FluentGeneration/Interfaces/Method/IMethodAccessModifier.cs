using FluentGeneration.Shared;

namespace FluentGeneration.Interfaces.Method
{
    public interface IMethodAccessModifier<out T>
    {
        IMethodType<T> WithAccessModifier(AccessModifiers accessModifier);
    }
}