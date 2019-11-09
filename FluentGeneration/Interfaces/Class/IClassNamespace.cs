using FluentGeneration.Shared;

namespace FluentGeneration.Interfaces.Class
{
    public interface IClassNamespace : IFluentLink<IClass>
    {
        IClassUsingDirectives WithNamespace(string name);
    }
}