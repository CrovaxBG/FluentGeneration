using FluentGeneration.Shared;

namespace FluentGeneration.Interfaces.Class
{
    public interface IClassAccessSpecifier<T> : IFluentLink<T>
        where T : IGeneratedObject
    {
        IClassType<T> WithAccessSpecifier(AccessSpecifier accessSpecifier);
    }
}
