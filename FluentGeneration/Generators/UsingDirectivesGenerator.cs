using System;
using System.IO;
using System.Linq;
using System.Reflection;
using FluentGeneration.Shared;

namespace FluentGeneration.Generators
{
    public class UsingDirectivesGenerator : IGeneratableHandler
    {
        private const string UsingDirectivesFileName = @"UsingDirectives.xml";
        public string Generate(GenerationData data)
        {
            if (data == null) { throw new ArgumentNullException(nameof(data)); }
            if (!(data.Data is string[] directives)) { throw new InvalidOperationException($"{nameof(data)} contains invalid data!"); }

            if (!directives.Any())
            {
                var buildDir = Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location);
                var path = $@"{buildDir}\{UsingDirectivesFileName}";
                directives = XmlReader.Read(path).UsingDirectives;
            }

            return string.Join(Environment.NewLine, directives.Select(d => $"using {d};"));
        }
    }
}