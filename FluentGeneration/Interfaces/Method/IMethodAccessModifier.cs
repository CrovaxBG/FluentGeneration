using FluentGeneration.Shared;

namespace FluentGeneration.Interfaces.Method
{
    public interface IMethodAccessModifier<T> : IFluentLink<T>
        where T : IGeneratedObject
    {
        IMethodType<T> WithAccessModifier(AccessModifiers accessModifier);
    }
}