using FluentGeneration.Shared;

namespace FluentGeneration.Interfaces.Interface
{
    public interface IInterfaceAccessSpecifier<T> : IFluentLink<T>
        where T : IGeneratedObject
    {
        IInterfaceName<T> WithAccessSpecifier(AccessSpecifier accessSpecifier);
    }
}