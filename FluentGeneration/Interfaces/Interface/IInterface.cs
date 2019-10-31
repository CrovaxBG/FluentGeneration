using FluentGeneration.Shared;

namespace FluentGeneration.Interfaces.Interface
{
    public interface IInterface : IFluentContainer<IInterface>, IGeneratedObject
    {
        void Build();
    }
}
