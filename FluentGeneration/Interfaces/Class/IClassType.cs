using FluentGeneration.Shared;

namespace FluentGeneration.Interfaces.Class
{
    public interface IClassType : IFluentLink<IClass>
    {
        IClassName WithClassType(FluentGeneration.Shared.ClassType classType);
    }
}