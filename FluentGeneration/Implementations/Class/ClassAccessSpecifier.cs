using System;
using FluentGeneration.Interfaces.Class;
using FluentGeneration.Shared;

namespace FluentGeneration.Implementations.Class
{
    public class ClassAccessSpecifier : IClassAccessSpecifier
    {
        private readonly IClassType _classType;

        private Func<IClass> _source;
        public Func<IClass> Source
        {
            get => _source;
            set
            {
                _source = value;
                _classType.Source = value;
            }
        }

        public ClassAccessSpecifier(IClassType classType)
        {
            _classType = classType ?? throw new ArgumentNullException(nameof(classType));
        }

        public IClassType WithAccessSpecifier(AccessSpecifier accessSpecifier)
        {
            if (accessSpecifier != AccessSpecifier.None)
            {
                Source.Invoke().Generator.AddGenerationData(typeof(IClassAccessSpecifier), accessSpecifier);
            }

            return _classType;
        }
    }
}
