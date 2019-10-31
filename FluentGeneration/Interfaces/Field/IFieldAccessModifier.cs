using FluentGeneration.Shared;

namespace FluentGeneration.Interfaces.Field
{
    public interface IFieldAccessModifier<T> : IFluentLink<T>
        where T : IGeneratedObject
    {
        IFieldType<T> WithAccessModifier(AccessModifiers accessModifier);
    }
}