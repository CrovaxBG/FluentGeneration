using System;
using System.Text;
using FluentGeneration.Interfaces.File;

namespace FluentGeneration.Shared
{
    public static class FileHelper
    {
        public static void CreateFile(IFile file)
        {
            if(file == null) { throw new ArgumentNullException(nameof(file)); }

            CreateFile(file.Path, file.Name, file.Body);
        }

        public static void CreateFile(string path, string name, string body)
        {
            if (string.IsNullOrEmpty(path)) { throw new ArgumentNullException(nameof(path));}
            if (string.IsNullOrEmpty(name)) { throw new ArgumentNullException(nameof(name));}

            var fileLocation = $"{path}/{name}.cs";
            using var stream = System.IO.File.Create(fileLocation);

            var data = new UTF8Encoding(true).GetBytes(body);
            stream.Write(data, 0, data.Length);
        }
    }
}