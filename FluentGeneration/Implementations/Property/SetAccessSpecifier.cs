using System;
using FluentGeneration.Interfaces.Property;
using FluentGeneration.Shared;

namespace FluentGeneration.Implementations.Property
{
    public class SetAccessSpecifier<T> : ISetAccessSpecifier<T>
        where T : IGeneratedObject
    {
        private readonly ISetBody<T> _setBody;

        private Func<T> _source;
        public Func<T> Source
        {
            get => _source;
            set
            {
                _source = value;
                _setBody.Source = value;
            }
        }

        public SetAccessSpecifier(ISetBody<T> setBody)
        {
            _setBody = setBody ?? throw new ArgumentNullException(nameof(setBody));
        }

        public ISetBody<T> WithSetAccessSpecifier(AccessSpecifier accessSpecifier)
        {
            if (accessSpecifier != AccessSpecifier.None)
            {
                Source.Invoke().Generator.AddGenerationData(typeof(ISetAccessSpecifier<>), accessSpecifier);
            }
            return _setBody;
        }
    }
}