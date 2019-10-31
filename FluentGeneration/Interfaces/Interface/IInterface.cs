using FluentGeneration.Shared;

namespace FluentGeneration.Interfaces.Interface
{
    public interface IInterface : IStorageContainer<IInterface>, IFluentContainer<IInterface>, IGeneratedObject
    {
        void Build();
    }
}
