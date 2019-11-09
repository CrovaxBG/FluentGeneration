using System;
using FluentGeneration.Interfaces.Class;

namespace FluentGeneration.Implementations.Class
{
    public class ClassNamespace : IClassNamespace
    {
        private readonly IClassUsingDirectives _usingDirectives;

        private Func<IClass> _source;
        public Func<IClass> Source
        {
            get => _source;
            set
            {
                _source = value;
                _usingDirectives.Source = value;
            }
        }

        public ClassNamespace(IClassUsingDirectives usingDirectives)
        {
            _usingDirectives = usingDirectives ?? throw new ArgumentNullException(nameof(usingDirectives));
        }

        public IClassUsingDirectives WithNamespace(string name)
        {
            Source.Invoke().Generator.AddGenerationData(typeof(IClassNamespace), name);
            return _usingDirectives;
        }
    }
}