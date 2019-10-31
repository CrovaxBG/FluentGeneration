using FluentGeneration.Shared;

namespace FluentGeneration.Interfaces.Property
{
    public interface IGetBody<T> : IFluentLink<T>
        where T : IGeneratedObject
    {
        ISetAccessSpecifier<T> AutoGet();
        ISetAccessSpecifier<T> WithGetBody(string body);
    }
}