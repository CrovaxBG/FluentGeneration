using FluentGeneration.Shared;

namespace FluentGeneration.Interfaces.Method
{
    public interface IMethodBody<T> : IFluentLink<T>
        where T : IGeneratedObject
    {
        T WithEmptyBody();
        T WithMethodBody(string body);
    }
}