using System;
using FluentGeneration.Generators;
using FluentGeneration.Interfaces.File;
using FluentGeneration.Interfaces.Interface;

namespace FluentGeneration.Implementations.Interface
{
    public class Interface : IInterface
    {
        private readonly IInterfaceNamespace _interfaceNamespace;

        public IGenerator Generator { get; }
        public string Data { get; private set; }

        public Func<IFileBody> Source { get; set; }

        public Interface(IGenerator codeGenerator, IInterfaceNamespace interfaceNamespace)
        {
            Generator = codeGenerator ?? throw new ArgumentNullException(nameof(codeGenerator));
            _interfaceNamespace = interfaceNamespace ?? throw new ArgumentNullException(nameof(interfaceNamespace));
            _interfaceNamespace.Source = () => this;
        }

        public IFileBody End()
        {
            Data = Generator.Generate(PatternConfig.InterfacePattern);
            Console.Clear();
            Console.WriteLine(Data);
            Source.Invoke().Generator.AddGenerationData(typeof(IInterface), Data);
            return Source.Invoke();
        }

        public IInterfaceNamespace Begin()
        {
            return _interfaceNamespace;
        }
    }
}