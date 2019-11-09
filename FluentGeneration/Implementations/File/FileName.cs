using System;
using FluentGeneration.Interfaces.File;

namespace FluentGeneration.Implementations.File
{
    public class FileName : IFileName
    {
        private readonly IFileBody _fileBody;

        private Func<IFile> _source;
        public Func<IFile> Source
        {
            get => _source;
            set
            {
                _source = value;
                _fileBody.Source = value;
            }
        }

        public FileName(IFileBody fileBody)
        {
            _fileBody = fileBody ?? throw new ArgumentNullException(nameof(fileBody));
        }

        public IFileBody WithName(string name)
        {
            if (string.IsNullOrEmpty(name)) { throw new InvalidOperationException(nameof(name)); }

            Source.Invoke().Name = name;
            return _fileBody;
        }
    }
}