using FluentGeneration.Shared;

namespace FluentGeneration.Interfaces.Interface
{
    public interface IInterfaceGenericArguments : IFluentLink<IInterface>
    {
        IInterfaceGenericArgumentsConstraints WithGenericArguments(params IGenericArgument[] arguments);
    }
}