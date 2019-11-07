using FluentGeneration.Shared;

namespace FluentGeneration.Interfaces.Class
{
    public interface IClassGenericArgumentsConstraints<T> : IFluentLink<T>
        where T : IGeneratedObject
    {
        IClassInheritance<T> WithGenericArgumentConstraint(params IGenericArgumentConstraint[] constraints);
        IClassInheritance<T> WithGenericArgumentConstraint(string literal);
    }
}