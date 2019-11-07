using System;
using FluentGeneration.Factories;
using FluentGeneration.Generators;
using FluentGeneration.Interfaces.Interface;
using FluentGeneration.Interfaces.Method;
using FluentGeneration.Interfaces.Property;
using FluentGeneration.Shared;

namespace FluentGeneration.Implementations.Interface
{
    public class InterfaceBody : IInterfaceBody
    {
        private readonly IFactory<IFluentLink<IInterfaceBody>> _factory;

        public IGenerator Generator { get; }
        public string Data { get; private set; }

        public Func<IInterface> Source { get; set; }

        public InterfaceBody(IGenerator generator, IFactory<IFluentLink<IInterfaceBody>> factory)
        {
            Generator = generator;
            _factory = factory;
        }

        public IInterface End()
        {
            Data = Generator.Generate(PatternConfig.InterfaceBodyPattern);
            Source.Invoke().Generator.AddGenerationData(typeof(IInterfaceBody), Data);
            Console.WriteLine(Data);
            return Source.Invoke();
        }

        public IProperty<IInterfaceBody> WithProperty()
        {
            return WithObject<IProperty<IInterfaceBody>>();
        }

        public IMethod<IInterfaceBody> WithMethod()
        {
            return WithObject<IMethod<IInterfaceBody>>();
        }

        public TObject WithObject<TObject>()
        {
            var instance = _factory.Create(typeof(TObject));
            instance.Source = () => this;
            return (TObject)instance;
        }
    }
}