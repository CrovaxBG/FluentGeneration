using FluentGeneration.Shared;

namespace FluentGeneration.Interfaces.Class
{
    public interface IClassAccessSpecifier : IFluentLink<IClass>
    {
        IClassType WithAccessSpecifier(AccessSpecifier accessSpecifier);
    }
}
