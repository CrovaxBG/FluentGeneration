using System;
using System.IO;
using FluentGeneration.Interfaces.File;

namespace FluentGeneration.Implementations.File
{
    public class FilePath : IFilePath
    {
        private readonly IFileName _fileName;

        private Func<IFile> _source;
        public Func<IFile> Source
        {
            get => _source;
            set
            {
                _source = value;
                _fileName.Source = value;
            }
        }

        public FilePath(IFileName fileName)
        {
            _fileName = fileName ?? throw new ArgumentNullException(nameof(fileName));
        }

        public IFileName WithPath(string path)
        {
            if (string.IsNullOrEmpty(path)) { throw new InvalidOperationException(nameof(path)); }

            return WithLocationImpl(path);
        }

        public IFileName WithPath(Uri location)
        {
            if (location == null) { throw new ArgumentNullException(nameof(location)); }
            if(string.IsNullOrEmpty(location.AbsolutePath)) { throw new InvalidOperationException(nameof(location)); }

            return WithLocationImpl(location.AbsolutePath);
        }

        public IFileName WithPath(DirectoryInfo directory)
        {
            if (directory == null) { throw new ArgumentNullException(nameof(directory)); }
            if(!directory.Exists) { throw new InvalidOperationException(nameof(directory));}
            if (string.IsNullOrEmpty(directory.FullName)) { throw new InvalidOperationException(nameof(directory));}

            return WithLocationImpl(directory.FullName);
        }

        private IFileName WithLocationImpl(string path)
        {
            Source.Invoke().Path = path;
            return _fileName;
        }
    }
}