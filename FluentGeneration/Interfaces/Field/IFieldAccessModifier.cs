using FluentGeneration.Interfaces.Class;
using FluentGeneration.Shared;

namespace FluentGeneration.Interfaces.Field
{
    public interface IFieldAccessModifier : IFluentLink<IField>
    {
        IFieldType WithAccessModifier(AccessModifiers accessModifier);
    }
}