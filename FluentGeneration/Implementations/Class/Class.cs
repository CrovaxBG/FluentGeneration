using System;
using FluentGeneration.Generators;
using FluentGeneration.Interfaces.Class;

namespace FluentGeneration.Implementations.Class
{
    public class Class : IClass
    {
        private readonly IClassAccessSpecifier _accessSpecifier;

        public IGenerator Generator { get; }
        public string Data { get; private set; }

        public Func<IFile> Source { get; set; }

        public Class(IGenerator codeGenerator, IClassAccessSpecifier accessSpecifier)
        {
            Generator = codeGenerator ?? throw new ArgumentNullException(nameof(codeGenerator));
            _accessSpecifier = accessSpecifier ?? throw new ArgumentNullException(nameof(accessSpecifier));
            _accessSpecifier.Source = () => this;
        }

        public IFile End()
        {
            Data = Generator.Generate(PatternConfig.ClassPattern);
            Console.Clear();
            Console.WriteLine(Data);
            if (Source == null)
            {
                //TODO Build file with class
                return null;
            }
            Source.Invoke().Generator.AddGenerationData(typeof(IClass), Data);
            return Source.Invoke();
        }

        public IClassAccessSpecifier Begin()
        {
            return _accessSpecifier;
        }
    }
}