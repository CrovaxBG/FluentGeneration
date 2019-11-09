using System;
using FluentGeneration.Interfaces.Interface;

namespace FluentGeneration.Implementations.Interface
{
    public class InterfaceUsingDirectives : IInterfaceUsingDirectives
    {
        private readonly IInterfaceAccessSpecifier _accessSpecifier;

        private Func<IInterface> _source;
        public Func<IInterface> Source
        {
            get => _source;
            set
            {
                _source = value;
                _accessSpecifier.Source = value;
            }
        }

        public InterfaceUsingDirectives(IInterfaceAccessSpecifier accessSpecifier)
        {
            _accessSpecifier = accessSpecifier ?? throw new ArgumentNullException(nameof(accessSpecifier));
        }

        public IInterfaceAccessSpecifier WithUsingDirectives(params string[] usingDirectives)
        {
            Source.Invoke().Generator.AddGenerationData(typeof(IInterfaceUsingDirectives), usingDirectives);
            return _accessSpecifier;
        }
    }
}