using System;
using FluentGeneration.Factories;
using FluentGeneration.Generators;
using FluentGeneration.Interfaces.Interface;
using FluentGeneration.Interfaces.Method;
using FluentGeneration.Interfaces.Property;
using FluentGeneration.Shared;

namespace FluentGeneration.Implementations.Interface
{
    public class InterfaceBody : BaseBody<IInterfaceBody, IInterface>,IInterfaceBody
    {
        IGenerator IGeneratedObject.Generator => base.Generator;
        public string Data { get; private set; }

        public Func<IInterface> Source { get; set; }

        protected override Func<IInterfaceBody> GetSource => () => this;

        public InterfaceBody(IGenerator generator, IFactory<IFluentLink<IInterfaceBody>> factory)
            : base(generator, factory)
        {
        }

        public IInterface End()
        {
            Data = Generator.Generate(PatternConfig.InterfaceBodyPattern);
            Source.Invoke().Generator.AddGenerationData(typeof(IInterfaceBody), Data);
            return Source.Invoke();
        }

        public IProperty<IInterfaceBody> WithProperty() => WithObject<IProperty<IInterfaceBody>>();
        public IMethod<IInterfaceBody> WithMethod() => WithObject<IMethod<IInterfaceBody>>();
        public IInterfaceBody WithProperties(SequenceGenerator<IProperty<IInterfaceBody>> sequenceGenerator) => WithMultipleObjects(sequenceGenerator);
        public IInterfaceBody WithMethods(SequenceGenerator<IMethod<IInterfaceBody>> sequenceGenerator) => WithMultipleObjects(sequenceGenerator);
    }
}