using FluentGeneration.Shared;

namespace FluentGeneration.Interfaces.Class
{
    public interface IClassType<T> : IFluentLink<T>
        where T : IGeneratedObject
    {
        IClassName<T> WithClassType(ClassType classType);
    }
}