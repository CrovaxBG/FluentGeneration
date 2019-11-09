using System;
using FluentGeneration.Interfaces.Interface;

namespace FluentGeneration.Implementations.Interface
{
    public class InterfaceNamespace : IInterfaceNamespace
    {
        private readonly IInterfaceUsingDirectives _usingDirectives;

        private Func<IInterface> _source;
        public Func<IInterface> Source
        {
            get => _source;
            set
            {
                _source = value;
                _usingDirectives.Source = value;
            }
        }

        public InterfaceNamespace(IInterfaceUsingDirectives usingDirectives)
        {
            _usingDirectives = usingDirectives ?? throw new ArgumentNullException(nameof(usingDirectives));
        }

        public IInterfaceUsingDirectives WithNamespace(string name)
        {
            Source.Invoke().Generator.AddGenerationData(typeof(IInterfaceNamespace), name);
            return _usingDirectives;
        }
    }
}