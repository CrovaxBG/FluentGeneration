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
    public class FileBody : BaseBody<IFileBody, IFile>, IFileBody
    {
        IGenerator IGeneratedObject.Generator => base.Generator;

        public string Data { get; private set; }

        public Func<IFile> Source { get; set; }

        protected override Func<IFileBody> GetSource => () => this;


        public FileBody(IGenerator generator, IFactory<IFluentLink<IFileBody>> factory)
            : base(generator, factory)
        {
        }

        public IFile End()
        {
            var code = Generator.Generate(PatternConfig.FileBodyPattern);
            Data = CSharpSyntaxTree.ParseText(code).GetRoot().NormalizeWhitespace().ToFullString();
            Source.Invoke().Body = Data;
            Console.WriteLine(Data);
            return Source.Invoke();
        }

        public IInterface WithInterface() => WithObject<IInterface>();
        public IClass WithClass() => WithObject<IClass>();
    }
}