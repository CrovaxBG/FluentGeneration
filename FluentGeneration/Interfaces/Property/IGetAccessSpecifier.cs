using FluentGeneration.Shared;

namespace FluentGeneration.Interfaces.Property
{
    public interface IGetAccessSpecifier<out T>
    {
        IGetBody<T> WithGetAccessSpecifier(AccessSpecifier accessSpecifier);
    }
}