using FluentGeneration.Interfaces.File;
using FluentGeneration.Shared;

namespace FluentGeneration.Interfaces.Interface
{
    public interface IInterface : IGeneratedObject, IFluentLink<IFileBody>, IEndable<IFileBody>,
        IBeginable<IInterfaceNamespace>
    {

    }
}
