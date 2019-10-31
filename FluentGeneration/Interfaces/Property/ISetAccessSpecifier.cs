using FluentGeneration.Shared;

namespace FluentGeneration.Interfaces.Property
{
    public interface ISetAccessSpecifier<out T>
    {
        ISetBody<T> WithSetAccessSpecifier(AccessSpecifier accessSpecifier);
    }
}