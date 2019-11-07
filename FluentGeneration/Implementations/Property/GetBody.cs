using System;
using FluentGeneration.Interfaces.Property;
using FluentGeneration.Shared;

namespace FluentGeneration.Implementations.Property
{
    public class GetBody<T> : IGetBody<T>
        where T : IGeneratedObject
    {
        private readonly ISetAccessSpecifier<T> _setAccessSpecifier;

        private Func<T> _source;
        public Func<T> Source
        {
            get => _source;
            set
            {
                _source = value;
                _setAccessSpecifier.Source = value;
            }
        }

        public GetBody(ISetAccessSpecifier<T> setAccessSpecifier)
        {
            _setAccessSpecifier = setAccessSpecifier;
        }

        public ISetAccessSpecifier<T> NoGet()
        {
            return _setAccessSpecifier;
        }

        public ISetAccessSpecifier<T> AutoGet()
        {
            Source.Invoke().Generator.AddGenerationData(typeof(IGetBody<>), new BodyData {IsAuto = true});
            return _setAccessSpecifier;
        }

        public ISetAccessSpecifier<T> WithGetBody(string body)
        {
            Source.Invoke().Generator.AddGenerationData(typeof(IGetBody<>), new BodyData {IsAuto = false, Body = body});
            return _setAccessSpecifier;
        }
    }
}