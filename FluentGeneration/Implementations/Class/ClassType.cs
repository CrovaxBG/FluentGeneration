using System;
using FluentGeneration.Interfaces.Class;

namespace FluentGeneration.Implementations.Class
{
    public class ClassType : IClassType
    {
        private readonly IClassName _className;

        private Func<IClass> _source;
        public Func<IClass> Source
        {
            get => _source;
            set
            {
                _source = value;
                _className.Source = value;
            }
        }

        public ClassType(IClassName className)
        {
            _className = className ?? throw new ArgumentNullException(nameof(className));
        }

        public IClassName WithClassType(FluentGeneration.Shared.ClassType classType)
        {
            if (classType != FluentGeneration.Shared.ClassType.Standard)
            {
                Source.Invoke().Generator.AddGenerationData(typeof(IClassType), classType);
            }

            return _className;
        }
    }
}