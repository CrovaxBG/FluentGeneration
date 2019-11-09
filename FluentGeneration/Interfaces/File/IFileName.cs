using FluentGeneration.Shared;

namespace FluentGeneration.Interfaces.File
{
    public interface IFileName : IFluentLink<IFile>
    {
        IFileBody WithName(string name);
    }
}