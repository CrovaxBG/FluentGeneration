using FluentGeneration.Shared;

namespace FluentGeneration.Interfaces.File
{
    public interface IFile : IFluentLink<FileBuilder>, IBeginable<IFilePath>, IEndable<FileBuilder>
    {
        string Path { get; set; }
        string Name { get; set; }
        string Body { get; set; }
    }
}
