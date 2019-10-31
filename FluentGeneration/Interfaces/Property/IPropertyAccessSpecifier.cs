using FluentGeneration.Shared;

namespace FluentGeneration.Interfaces.Property
{
    public interface IPropertyAccessSpecifier<T> : IFluentLink<T> 
        where T : IGeneratedObject
    {
        IPropertyAccessModifier<T> WithAccessSpecifier(AccessSpecifier accessSpecifier);
    }
}