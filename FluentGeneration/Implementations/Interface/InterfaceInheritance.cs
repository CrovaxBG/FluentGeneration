using System;
using System.Linq;
using FluentGeneration.Interfaces.Interface;

namespace FluentGeneration.Implementations.Interface
{
    public class InterfaceInheritance : IInterfaceInheritance
    {
        private readonly IInterfaceBody _interfaceBody;

        private Func<IInterface> _source;
        public Func<IInterface> Source
        {
            get => _source;
            set
            {
                _source = value;
                _interfaceBody.Source = value;
            }
        }

        public InterfaceInheritance(IInterfaceBody interfaceBody)
        {
            _interfaceBody = interfaceBody;
        }

        public IInterfaceBody WithInheritance(params Type[] types)
        {
            if (types.Any())
            {
                Source.Invoke().Generator.AddGenerationData(typeof(IInterfaceInheritance), types);
            }

            return _interfaceBody;
        }

        public IInterfaceBody WithInheritance(string literal)
        {
            if (!string.IsNullOrEmpty(literal))
            {
                Source.Invoke().Generator.AddGenerationData(typeof(IInterfaceInheritance), literal);
            }

            return _interfaceBody;
        }
    }
}