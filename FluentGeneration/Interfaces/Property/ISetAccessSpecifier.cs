using FluentGeneration.Shared;

namespace FluentGeneration.Interfaces.Property
{
    public interface ISetAccessSpecifier<T> : IFluentLink<T>
        where T : IGeneratedObject
    {
        ISetBody<T> WithSetAccessSpecifier(AccessSpecifier accessSpecifier);
    }
}