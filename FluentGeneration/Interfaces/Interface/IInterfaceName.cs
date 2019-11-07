using FluentGeneration.Shared;

namespace FluentGeneration.Interfaces.Interface
{
    public interface IInterfaceName : IFluentLink<IInterface>
    {
        IInterfaceAttribute WithName(string name);
    }
}