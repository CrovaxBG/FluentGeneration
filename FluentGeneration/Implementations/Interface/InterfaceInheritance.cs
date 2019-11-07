using System;
using System.Linq;
using FluentGeneration.Interfaces.Interface;
using FluentGeneration.Shared;

namespace FluentGeneration.Implementations.Interface
{
    public class InterfaceInheritance<T> : IInterfaceInheritance<T>
        where T : IGeneratedObject
    {
        private readonly IInterfaceBody<T> _interfaceBody;

        private Func<T> _source;
        public Func<T> Source
        {
            get => _source;
            set
            {
                _source = value;
                _interfaceBody.Source = value;
            }
        }

        public InterfaceInheritance(IInterfaceBody<T> interfaceBody)
        {
            _interfaceBody = interfaceBody;
        }

        public IInterfaceBody<T> WithInheritance(params Type[] types)
        {
            if (types.Any())
            {
                Source.Invoke().Generator.AddGenerationData(typeof(IInterfaceInheritance<>), types);
            }

            return _interfaceBody;
        }

        public IInterfaceBody<T> WithInheritance(string literal)
        {
            if (!string.IsNullOrEmpty(literal))
            {
                Source.Invoke().Generator.AddGenerationData(typeof(IInterfaceInheritance<>), literal);
            }

            return _interfaceBody;
        }
    }
}