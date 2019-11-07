using FluentGeneration.Shared;

namespace FluentGeneration.Interfaces.Interface
{
    public interface IInterfaceGenericArguments<T> : IFluentLink<T>
        where T : IGeneratedObject
    {
        IInterfaceGenericArgumentsConstraints<T> WithGenericArguments(params IGenericArgument[] arguments);
    }
}