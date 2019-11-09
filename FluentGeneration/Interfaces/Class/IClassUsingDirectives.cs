using FluentGeneration.Shared;

namespace FluentGeneration.Interfaces.Class
{
    public interface IClassUsingDirectives : IFluentLink<IClass>
    {
        IClassAccessSpecifier WithUsingDirectives(params string[] usingDirectives);
    }
}