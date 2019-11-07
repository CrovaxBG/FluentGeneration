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
    public class ClassBody : IClassBody
    {
        private readonly IFactory<IFluentLink<IClassBody>> _factory;

        public IGenerator Generator { get; }
        public string Data { get; private set; }

        public Func<IClass> Source { get; set; }

        public ClassBody(IGenerator generator, IFactory<IFluentLink<IClassBody>> factory)
        {
            Generator = generator ?? throw new ArgumentNullException(nameof(generator));
            _factory = factory ?? throw new ArgumentNullException(nameof(factory));
        }

        public IClass End()
        {
            Data = Generator.Generate(PatternConfig.ClassBodyPattern);
            Source.Invoke().Generator.AddGenerationData(typeof(IClassBody), Data);
            Console.WriteLine(Data);
            return Source.Invoke();
        }

        public IField WithField()
        {
            return WithObject<IField>();
        }

        public IProperty<IClassBody> WithProperty()
        {
            return WithObject<IProperty<IClassBody>>();
        }

        public IMethod<IClassBody> WithMethod()
        {
            return WithObject<IMethod<IClassBody>>();
        }

        public TObject WithObject<TObject>()
        {
            var instance = _factory.Create(typeof(TObject));
            instance.Source = () => this;
            return (TObject)instance;
        }
    }
}