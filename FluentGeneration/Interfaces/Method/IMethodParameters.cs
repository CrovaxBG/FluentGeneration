using FluentGeneration.Shared;

namespace FluentGeneration.Interfaces.Method
{
    public interface IMethodParameters<out T>
    {
        IMethodBody<T> WithParameters(params IParameter[] parameterType);
    }
}