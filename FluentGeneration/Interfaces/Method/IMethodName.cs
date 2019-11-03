using FluentGeneration.Shared;

namespace FluentGeneration.Interfaces.Method
{
    public interface IMethodName<T> : IFluentLink<T>
        where T : IGeneratedObject
    {
        IMethodAttribute<T> WithName(string name);
    }
}