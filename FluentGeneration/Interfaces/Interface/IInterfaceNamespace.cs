using FluentGeneration.Shared;

namespace FluentGeneration.Interfaces.Interface
{
    public interface IInterfaceNamespace : IFluentLink<IInterface>
    {
        IInterfaceUsingDirectives WithNamespace(string name);
    }
}