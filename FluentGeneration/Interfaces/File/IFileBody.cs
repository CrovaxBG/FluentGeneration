using FluentGeneration.Interfaces.Class;
using FluentGeneration.Interfaces.Interface;
using FluentGeneration.Shared;

namespace FluentGeneration.Interfaces.File
{
    public interface IFileBody : IGeneratedObject, IFluentLink<IFile>, IEndable<IFile>
    {
        IInterface WithInterface();
        IClass WithClass();
    }
}