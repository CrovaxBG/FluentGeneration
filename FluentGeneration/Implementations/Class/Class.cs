using System;
using FluentGeneration.Factories;
using FluentGeneration.Generators;
using FluentGeneration.Interfaces.Class;
using FluentGeneration.Interfaces.Field;
using FluentGeneration.Interfaces.Method;
using FluentGeneration.Interfaces.Property;
using FluentGeneration.Shared;

namespace FluentGeneration.Implementations.Class
{
    public class Class : IClass
    {
        private readonly IFactory<IFluentLink<IClass>> _factory;

        public IGenerator Generator { get; }
        public string Data { get; }

        public Class(IGenerator codeGenerator, IFactory<IFluentLink<IClass>> factory)
        {
            _factory = factory;
            Generator = codeGenerator;
        }

        public IField<IClass> WithField()
        {
            var instance = _factory.Create(typeof(IField<IClass>));
            instance.Source = () => this;
            return (IField<IClass>) instance;
        }

        public IProperty<IClass> WithProperty()
        {
            var instance = _factory.Create(typeof(IProperty<IClass>));
            instance.Source = () => this;
            return (IProperty<IClass>) instance;
        }

        public IMethod<IClass> WithMethod()
        {
            var instance = _factory.Create(typeof(IMethod<IClass>));
            instance.Source = () => this;
            return (IMethod<IClass>)instance;
        }

        public void Build()
        {
            throw new NotImplementedException();
        }
    }
}
