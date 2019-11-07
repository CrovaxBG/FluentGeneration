using System;
using FluentGeneration.Interfaces.Class;
using FluentGeneration.Shared;

namespace FluentGeneration.Implementations.Class
{
    public class ClassName<T> : IClassName<T>
        where T : IGeneratedObject
    {
        private readonly IClassAttribute<T> _classAttribute;

        private Func<T> _source;
        public Func<T> Source
        {
            get => _source;
            set
            {
                _source = value;
                _classAttribute.Source = value;
            }
        }

        public ClassName(IClassAttribute<T> classAttribute)
        {
            _classAttribute = classAttribute;
        }

        public IClassAttribute<T> WithName(string name)
        {
            Source.Invoke().Generator.AddGenerationData(typeof(IClassName<>), name);
            return _classAttribute;
        }
    }
}