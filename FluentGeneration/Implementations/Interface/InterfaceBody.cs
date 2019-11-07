using System;
using FluentGeneration.Factories;
using FluentGeneration.Generators;
using FluentGeneration.Interfaces.Interface;
using FluentGeneration.Interfaces.Method;
using FluentGeneration.Interfaces.Property;
using FluentGeneration.Shared;

namespace FluentGeneration.Implementations.Interface
{
    public class InterfaceBody<T> : IInterfaceBody<T>
        where T : IGeneratedObject
    {
        private readonly IFactory<IFluentLink<IInterfaceBody<T>>> _factory;

        public IGenerator Generator { get; }
        public string Data { get; private set; }

        public Func<T> Source { get; set; }

        public InterfaceBody(IGenerator generator, IFactory<IFluentLink<IInterfaceBody<T>>> factory)
        {
            Generator = generator;
            _factory = factory;
        }

        public T End()
        {
            Data = Generator.Generate(PatternConfig.InterfaceBodyPattern);
            Source.Invoke().Generator.AddGenerationData(typeof(IInterfaceBody<>), Data);
            Console.WriteLine(Data);
            return Source.Invoke();
        }

        public IProperty<IInterfaceBody<T>> WithProperty()
        {
            return WithObject<IProperty<IInterfaceBody<T>>>();
        }

        public IMethod<IInterfaceBody<T>> WithMethod()
        {
            return WithObject<IMethod<IInterfaceBody<T>>>();
        }

        public TObject WithObject<TObject>()
        {
            var instance = _factory.Create(typeof(TObject));
            instance.Source = () => this;
            return (TObject)instance;
        }
    }
}