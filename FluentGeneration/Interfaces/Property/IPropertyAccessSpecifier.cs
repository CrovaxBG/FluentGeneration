using FluentGeneration.Shared;

namespace FluentGeneration.Interfaces.Property
{
    public interface IPropertyAccessSpecifier<out T>
    {
        IPropertyAccessModifier<T> WithAccessSpecifier(AccessSpecifier accessSpecifier);
    }
}