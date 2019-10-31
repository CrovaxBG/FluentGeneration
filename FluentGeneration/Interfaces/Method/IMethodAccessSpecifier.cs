using FluentGeneration.Shared;

namespace FluentGeneration.Interfaces.Method
{
    public interface IMethodAccessSpecifier<out T>
    {
        IMethodAccessModifier<T> WithAccessSpecifier(AccessSpecifier accessSpecifier);
    }
}