using FluentGeneration.Shared;

namespace FluentGeneration.Interfaces.Class
{
    public interface IClass : IFluentContainer<IClass>, IGeneratedObject
    {
        void Build();
    }
}
