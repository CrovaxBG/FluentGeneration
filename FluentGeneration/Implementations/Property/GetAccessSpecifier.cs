using System;
using FluentGeneration.Interfaces.Property;
using FluentGeneration.Shared;

namespace FluentGeneration.Implementations.Property
{
    public class GetAccessSpecifier<T> : IGetAccessSpecifier<T>
        where T : IGeneratedObject
    {
        private readonly IGetBody<T> _getBody;

        private Func<T> _source;
        public Func<T> Source
        {
            get => _source;
            set
            {
                _source = value;
                _getBody.Source = value;
            }
        }

        public GetAccessSpecifier(IGetBody<T> getBody)
        {
            _getBody = getBody;
        }

        public IGetBody<T> WithGetAccessSpecifier(AccessSpecifier accessSpecifier)
        {
            if (accessSpecifier != AccessSpecifier.None)
            {
                Source.Invoke().Generator.AddGenerationData(typeof(IGetAccessSpecifier<>), accessSpecifier);
            }
            return _getBody;
        }
    }
}