using System;
using System.Linq;
using FluentGeneration.Interfaces.Class;

namespace FluentGeneration.Implementations.Class
{
    public class ClassUsingDirectives : IClassUsingDirectives
    {
        private readonly IClassAccessSpecifier _accessSpecifier;

        private Func<IClass> _source;
        public Func<IClass> Source
        {
            get => _source;
            set
            {
                _source = value;
                _accessSpecifier.Source = value;
            }
        }

        public ClassUsingDirectives(IClassAccessSpecifier accessSpecifier)
        {
            _accessSpecifier = accessSpecifier ?? throw new ArgumentNullException(nameof(accessSpecifier));
        }

        public IClassAccessSpecifier WithUsingDirectives(params string[] usingDirectives)
        {
            Source.Invoke().Generator.AddGenerationData(typeof(IClassUsingDirectives), usingDirectives);
            return _accessSpecifier;
        }
    }
}