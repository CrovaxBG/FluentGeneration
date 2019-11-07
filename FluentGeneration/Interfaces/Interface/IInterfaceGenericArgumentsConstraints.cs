using FluentGeneration.Shared;

namespace FluentGeneration.Interfaces.Interface
{
    public interface IInterfaceGenericArgumentsConstraints<T> : IFluentLink<T>
        where T : IGeneratedObject
    {
        IInterfaceInheritance<T> WithGenericArgumentConstraint(params IGenericArgumentConstraint[] constraints);
        IInterfaceInheritance<T> WithGenericArgumentConstraint(string literal);
    }
}