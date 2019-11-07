using FluentGeneration.Shared;

namespace FluentGeneration.Interfaces.Class
{
    public interface IClassName : IFluentLink<IClass>
    {
        IClassAttribute WithName(string name);
    }
}