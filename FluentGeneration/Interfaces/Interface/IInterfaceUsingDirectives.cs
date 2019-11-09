using FluentGeneration.Shared;

namespace FluentGeneration.Interfaces.Interface
{
    public interface IInterfaceUsingDirectives : IFluentLink<IInterface>
    {
        IInterfaceAccessSpecifier WithUsingDirectives(params string[] usingDirectives);
    }
}