using FluentGeneration.Shared;

namespace FluentGeneration.Interfaces.Field
{
    public interface IFieldAccessSpecifier<T> : IFluentLink<T>
        where T : IGeneratedObject
    {
        IFieldAccessModifier<T> WithAccessSpecifier(AccessSpecifier accessSpecifier);
    }
}