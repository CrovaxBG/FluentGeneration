using FluentGeneration.Shared;

namespace FluentGeneration.Interfaces.Interface
{
    public interface IInterfaceName<T> : IFluentLink<T>
        where T : IGeneratedObject
    {
        IInterfaceAttribute<T> WithName(string name);
    }
}