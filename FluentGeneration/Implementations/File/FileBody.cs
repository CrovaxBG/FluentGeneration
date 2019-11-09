using System;
using FluentGeneration.Factories;
using FluentGeneration.Generators;
using FluentGeneration.Interfaces.Class;
using FluentGeneration.Interfaces.File;
using FluentGeneration.Interfaces.Interface;
using FluentGeneration.Shared;
using Microsoft.CodeAnalysis;
using Microsoft.CodeAnalysis.CSharp;

namespace FluentGeneration.Implementations.File
{
    public class FileBody : IFileBody
    {
        private readonly IFactory<IFluentLink<IFileBody>> _factory;

        public IGenerator Generator { get; }
        public string Data { get; private set; }

        public Func<IFile> Source { get; set; }

        public FileBody(IGenerator generator, IFactory<IFluentLink<IFileBody>> factory)
        {
            Generator = generator ?? throw new ArgumentNullException(nameof(generator));
            _factory = factory ?? throw new ArgumentNullException(nameof(factory));
        }

        public IFile End()
        {
            var code = Generator.Generate(PatternConfig.FileBodyPattern);
            Data = CSharpSyntaxTree.ParseText(code).GetRoot().NormalizeWhitespace().ToFullString();
            Source.Invoke().Body = Data;
            Console.WriteLine(Data);
            return Source.Invoke();
        }

        public IInterface WithInterface()
        {
            return WithObject<IInterface>();
        }

        public IClass WithClass()
        {
            return WithObject<IClass>();
        }

        public TObject WithObject<TObject>()
        {
            var instance = _factory.Create(typeof(TObject));
            instance.Source = () => this;
            return (TObject)instance;
        }
    }
}