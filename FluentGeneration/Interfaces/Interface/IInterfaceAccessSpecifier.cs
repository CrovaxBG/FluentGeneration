using FluentGeneration.Shared;

namespace FluentGeneration.Interfaces.Interface
{
    public interface IInterfaceAccessSpecifier : IFluentLink<IInterface>
    {
        IInterfaceName WithAccessSpecifier(AccessSpecifier accessSpecifier);
    }
}