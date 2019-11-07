using FluentGeneration.Shared;

namespace FluentGeneration.Interfaces.Class
{
    public interface IClassGenericArgumentsConstraints : IFluentLink<IClass>
    {
        IClassInheritance WithGenericArgumentConstraint(params IGenericArgumentConstraint[] constraints);
        IClassInheritance WithGenericArgumentConstraint(string literal);
    }
}