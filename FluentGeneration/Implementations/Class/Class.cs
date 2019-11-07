using System;
using FluentGeneration.Generators;
using FluentGeneration.Interfaces.Class;
using FluentGeneration.Interfaces.Field;

namespace FluentGeneration.Implementations.Class
{
    public class Class : IClass
    {
        private readonly IClassAccessSpecifier<IClass> _accessSpecifier;

        public IGenerator Generator { get; }
        public string Data { get; private set; }

        public Func<IFile> Source { get; set; }

        public Class(IGenerator codeGenerator, IClassAccessSpecifier<IClass> accessSpecifier)
        {
            Generator = codeGenerator;
            _accessSpecifier = accessSpecifier;
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

        public IClassAccessSpecifier<IClass> Begin()
        {
            return _accessSpecifier;
        }
    }
}