using FluentGeneration.Shared;

namespace FluentGeneration.Interfaces.Class
{
    public interface IClassName<T> : IFluentLink<T>
        where T : IGeneratedObject
    {
        IClassAttribute<T> WithClassName(string name);
    }
}