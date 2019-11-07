using FluentGeneration.Shared;

namespace FluentGeneration.Interfaces.Interface
{
    public interface IInterfaceGenericArgumentsConstraints : IFluentLink<IInterface>
    {
        IInterfaceInheritance WithGenericArgumentConstraint(params IGenericArgumentConstraint[] constraints);
        IInterfaceInheritance WithGenericArgumentConstraint(string literal);
    }
}