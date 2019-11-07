using System;
using FluentGeneration.Generators;
using FluentGeneration.Interfaces.Class;
using FluentGeneration.Interfaces.File;
using FluentGeneration.Interfaces.Interface;

namespace FluentGeneration.Implementations.Interface
{
    public class Interface : IInterface
    {
        private readonly IInterfaceAccessSpecifier _accessSpecifier;

        public IGenerator Generator { get; }
        public string Data { get; private set; }

        public Func<IFile> Source { get; set; }

        public Interface(IGenerator codeGenerator, IInterfaceAccessSpecifier accessSpecifier)
        {
            Generator = codeGenerator ?? throw new ArgumentNullException(nameof(codeGenerator));
            _accessSpecifier = accessSpecifier ?? throw new ArgumentNullException(nameof(accessSpecifier));
            _accessSpecifier.Source = () => this;
        }

        public IFile End()
        {
            Data = Generator.Generate(PatternConfig.InterfacePattern);
            Console.Clear();
            Console.WriteLine(Data);
            if (Source == null)
            {
                //TODO Build file with interface
                return null;
            }
            Source.Invoke().Generator.AddGenerationData(typeof(IInterface), Data);
            return Source.Invoke();
        }

        public IInterfaceAccessSpecifier Begin()
        {
            return _accessSpecifier;
        }
    }
}