using System;
using FluentGeneration.Generators;
using FluentGeneration.Interfaces.Class;
using FluentGeneration.Interfaces.Field;
using FluentGeneration.Interfaces.Method;
using FluentGeneration.Interfaces.Property;

namespace FluentGeneration.Implementations.Class
{
    public class Class : IClass
    {
        private readonly IFactory<IField<IClass>> _factory;

        public IGenerator Generator { get; }
        public string Data { get; }

        public Class(IGenerator codeGenerator, IFactory<IField<IClass>> factory)
        {
            _factory = factory;
            Generator = codeGenerator;
        }

        public IField<IClass> WithField()
        {
            var instance = _factory.Create(typeof(IField<IClass>));
            instance.Source = () => this;
            return instance;
        }

        public IProperty<IClass> WithProperty()
        {
            throw new NotImplementedException();
        }

        public IMethod<IClass> WithMethod()
        {
            throw new NotImplementedException();
        }

        public void Build()
        {
            throw new NotImplementedException();
        }
    }
}
