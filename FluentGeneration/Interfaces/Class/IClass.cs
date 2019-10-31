using FluentGeneration.Shared;

namespace FluentGeneration.Interfaces.Class
{
    public interface IClass : IStorageContainer<IClass>, IFluentContainer<IClass>, IGeneratedObject
    {
        void Build();
    }
}
