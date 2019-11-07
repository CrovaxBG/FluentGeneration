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
    public class ClassBody<T> : IClassBody<T>
        where T : IGeneratedObject
    {
        private readonly IFactory<IFluentLink<IClassBody<T>>> _factory;

        public IGenerator Generator { get; }
        public string Data { get; private set; }

        public Func<T> Source { get; set; }

        public ClassBody(IGenerator generator, IFactory<IFluentLink<IClassBody<T>>> factory)
        {
            Generator = generator;
            _factory = factory;
        }

        public T End()
        {
            Data = Generator.Generate(PatternConfig.ClassBodyPattern);
            Source.Invoke().Generator.AddGenerationData(typeof(IClassBody<>), Data);
            Console.WriteLine(Data);
            return Source.Invoke();
        }

        public IField<IClassBody<T>> WithField()
        {
            return WithObject<IField<IClassBody<T>>>();
        }

        public IProperty<IClassBody<T>> WithProperty()
        {
            return WithObject<IProperty<IClassBody<T>>>();
        }

        public IMethod<IClassBody<T>> WithMethod()
        {
            return WithObject<IMethod<IClassBody<T>>>();
        }

        public TObject WithObject<TObject>()
        {
            var instance = _factory.Create(typeof(TObject));
            instance.Source = () => this;
            return (TObject)instance;
        }
    }
}