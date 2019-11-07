using System;
using FluentGeneration.Interfaces.Class;
using FluentGeneration.Shared;

namespace FluentGeneration.Implementations.Class
{
    public class ClassAccessSpecifier<T> : IClassAccessSpecifier<T>
        where T : IGeneratedObject
    {
        private readonly IClassType<T> _classType;

        private Func<T> _source;
        public Func<T> Source
        {
            get => _source;
            set
            {
                _source = value;
                _classType.Source = value;
            }
        }

        public ClassAccessSpecifier(IClassType<T> classType)
        {
            _classType = classType;
        }

        public IClassType<T> WithAccessSpecifier(AccessSpecifier accessSpecifier)
        {
            if (accessSpecifier != AccessSpecifier.None)
            {
                Source.Invoke().Generator.AddGenerationData(typeof(IClassAccessSpecifier<>), accessSpecifier);
            }

            return _classType;
        }
    }
}
