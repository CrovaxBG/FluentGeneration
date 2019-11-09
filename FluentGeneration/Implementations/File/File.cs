using System;
using FluentGeneration.Interfaces.File;

namespace FluentGeneration.Implementations.File
{
    public class File : IFile
    {
        private readonly IFilePath _filePath;

        public string Path { get; set; }
        public string Name { get; set; }
        public string Body { get; set; }

        public Func<FileBuilder> Source { get; set; }

        public File(IFilePath filePath)
        {
            _filePath = filePath ?? throw new ArgumentNullException(nameof(filePath));
            _filePath.Source = () => this;
        }

        public FileBuilder End()
        {
            var source = Source.Invoke();
            source.AddFile(this);
            return source;
        }

        public IFilePath Begin()
        {
            return _filePath;
        }
    }
}