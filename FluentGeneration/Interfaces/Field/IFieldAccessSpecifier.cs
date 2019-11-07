using FluentGeneration.Interfaces.Class;
using FluentGeneration.Shared;

namespace FluentGeneration.Interfaces.Field
{
    public interface IFieldAccessSpecifier : IFluentLink<IField>
    {
        IFieldAccessModifier WithAccessSpecifier(AccessSpecifier accessSpecifier);
    }
}