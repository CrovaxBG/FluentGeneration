using FluentGeneration.Shared;

namespace FluentGeneration.Interfaces.Class
{
    public interface IClassGenericArguments<T> : IFluentLink<T>
        where T : IGeneratedObject
    {
        IClassGenericArgumentsConstraints<T> WithGenericArguments(params IGenericArgument[] arguments);
    }
}