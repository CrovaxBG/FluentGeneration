using System;
using FluentGeneration.Interfaces.Class;
using FluentGeneration.Shared;

namespace FluentGeneration.Implementations.Class
{
    public class ClassType<T> : IClassType<T>
        where T : IGeneratedObject
    {
        private readonly IClassName<T> _className;

        private Func<T> _source;
        public Func<T> Source
        {
            get => _source;
            set
            {
                _source = value;
                _className.Source = value;
            }
        }

        public ClassType(IClassName<T> className)
        {
            _className = className;
        }

        public IClassName<T> WithClassType(ClassType classType)
        {
            if (classType != ClassType.Standard)
            {
                Source.Invoke().Generator.AddGenerationData(typeof(IClassType<>), classType);
            }

            return _className;
        }
    }
}