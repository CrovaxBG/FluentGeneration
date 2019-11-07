using System;
using System.Linq;
using FluentGeneration.Interfaces.Class;

namespace FluentGeneration.Implementations.Class
{
    public class ClassInheritance : IClassInheritance
    {
        private readonly IClassBody _classBody;

        private Func<IClass> _source;
        public Func<IClass> Source
        {
            get => _source;
            set
            {
                _source = value;
                _classBody.Source = value;
            }
        }

        public ClassInheritance(IClassBody classBody)
        {
            _classBody = classBody;
        }

        public IClassBody WithInheritance(params Type[] types)
        {
            if (types.Any())
            {
                Source.Invoke().Generator.AddGenerationData(typeof(IClassInheritance), types);
            }
            return _classBody;
        }

        public IClassBody WithInheritance(string literal)
        {
            if (!string.IsNullOrEmpty(literal))
            {
                Source.Invoke().Generator.AddGenerationData(typeof(IClassInheritance), literal);
            }

            return _classBody;
        }
    }
}