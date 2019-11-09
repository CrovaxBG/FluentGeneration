using System;
using System.IO;
using FluentGeneration.Shared;

namespace FluentGeneration.Interfaces.File
{
    public interface IFilePath : IFluentLink<IFile>
    {
        IFileName WithPath(string path);
        IFileName WithPath(Uri location);
        IFileName WithPath(DirectoryInfo directory);
    }
}