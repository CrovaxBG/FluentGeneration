using FluentGeneration.Interfaces.File;
using FluentGeneration.Shared;

namespace FluentGeneration.Interfaces.Class
{
    public interface IClass : IGeneratedObject, IFluentLink<IFileBody>, IEndable<IFileBody>,
        IBeginable<IClassNamespace>
    {

    }
}
