using FluentGeneration.Shared;

namespace FluentGeneration.Interfaces.Property
{
    public interface IGetAccessSpecifier<T> : IFluentLink<T>
        where T : IGeneratedObject
    {
        IGetBody<T> WithGetAccessSpecifier(AccessSpecifier accessSpecifier);
    }
}