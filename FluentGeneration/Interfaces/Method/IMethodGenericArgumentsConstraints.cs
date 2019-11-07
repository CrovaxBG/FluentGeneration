using FluentGeneration.Shared;

namespace FluentGeneration.Interfaces.Method
{
    public interface IMethodGenericArgumentsConstraints<T> : IFluentLink<T>
        where T : IGeneratedObject
    {
        IMethodParameters<T> WithGenericArgumentConstraint(params IGenericArgumentConstraint[] constraints);
        IMethodParameters<T> WithGenericArgumentConstraint(string literal);
    }
}