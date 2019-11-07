using System;
using System.Linq;
using FluentGeneration.Interfaces.Class;
using FluentGeneration.Shared;

namespace FluentGeneration.Implementations.Class
{
    public class ClassInheritance<T> : IClassInheritance<T>
        where T : IGeneratedObject
    {
        private readonly IClassBody<T> _classBody;

        private Func<T> _source;
        public Func<T> Source
        {
            get => _source;
            set
            {
                _source = value;
                _classBody.Source = value;
            }
        }

        public ClassInheritance(IClassBody<T> classBody)
        {
            _classBody = classBody;
        }

        public IClassBody<T> WithInheritance(params Type[] types)
        {
            if (types.Any())
            {
                Source.Invoke().Generator.AddGenerationData(typeof(IClassInheritance<>), types);
            }
            return _classBody;
        }

        public IClassBody<T> WithInheritance(string literal)
        {
            if (!string.IsNullOrEmpty(literal))
            {
                Source.Invoke().Generator.AddGenerationData(typeof(IClassInheritance<>), literal);
            }

            return _classBody;
        }
    }
}