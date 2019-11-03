using FluentGeneration.Shared;

namespace FluentGeneration.Interfaces.Method
{
    public interface IMethodParameters<T> : IFluentLink<T>
        where T : IGeneratedObject
    {
        IMethodBody<T> WithParameters(params IParameter[] parameterType);
    }
}