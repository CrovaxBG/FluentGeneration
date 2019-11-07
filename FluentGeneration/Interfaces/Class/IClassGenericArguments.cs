using FluentGeneration.Shared;

namespace FluentGeneration.Interfaces.Class
{
    public interface IClassGenericArguments : IFluentLink<IClass>
    {
        IClassGenericArgumentsConstraints WithGenericArguments(params IGenericArgument[] arguments);
    }
}