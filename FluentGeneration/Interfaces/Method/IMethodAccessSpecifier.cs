using FluentGeneration.Shared;

namespace FluentGeneration.Interfaces.Method
{
    public interface IMethodAccessSpecifier<T> : IFluentLink<T>
        where T : IGeneratedObject
    {
        IMethodAccessModifier<T> WithAccessSpecifier(AccessSpecifier accessSpecifier);
    }
}