using System;
using FluentGeneration.Generators;
using FluentGeneration.Interfaces.Class;
using FluentGeneration.Interfaces.File;

namespace FluentGeneration.Implementations.Class
{
    public class Class : IClass
    {
        private readonly IClassNamespace _namespace;

        public IGenerator Generator { get; }
        public string Data { get; private set; }

        public Func<IFileBody> Source { get; set; }

        public Class(IGenerator codeGenerator, IClassNamespace @namespace)
        {
            Generator = codeGenerator ?? throw new ArgumentNullException(nameof(codeGenerator));
            _namespace = @namespace ?? throw new ArgumentNullException(nameof(@namespace));
            _namespace.Source = () => this;
        }

        public IFileBody End()
        {
            Data = Generator.Generate(PatternConfig.ClassPattern);
            Source.Invoke().Generator.AddGenerationData(typeof(IClass), Data);
            return Source.Invoke();
        }

        public IClassNamespace Begin()
        {
            return _namespace;
        }
    }
}