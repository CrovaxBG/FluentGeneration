using System;
using FluentGeneration.Interfaces.Class;

namespace FluentGeneration.Implementations.Class
{
    public class ClassName : IClassName
    {
        private readonly IClassAttribute _classAttribute;

        private Func<IClass> _source;
        public Func<IClass> Source
        {
            get => _source;
            set
            {
                _source = value;
                _classAttribute.Source = value;
            }
        }

        public ClassName(IClassAttribute classAttribute)
        {
            _classAttribute = classAttribute ?? throw new ArgumentNullException(nameof(classAttribute));
        }

        public IClassAttribute WithName(string name)
        {
            if(name == null) { throw new ArgumentNullException(nameof(name)); }

            Source.Invoke().Generator.AddGenerationData(typeof(IClassName), name);
            return _classAttribute;
        }
    }
}