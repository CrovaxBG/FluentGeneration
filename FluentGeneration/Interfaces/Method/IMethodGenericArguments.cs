using FluentGeneration.Shared;

namespace FluentGeneration.Interfaces.Method
{
    public interface IMethodGenericArguments<T> : IFluentLink<T>
        where T : IGeneratedObject
    {
        IMethodGenericArgumentsConstraints<T> WithGenericArguments(params IGenericArgument[] arguments);
        IMethodGenericArgumentsConstraints<T> WithGenericArguments(string literal);
    }
}