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
    public class ClassBody : BaseBody<IClassBody, IClass>, IClassBody
    {
        IGenerator IGeneratedObject.Generator => base.Generator;

        public string Data { get; private set; }

        public Func<IClass> Source { get; set; }

        protected override Func<IClassBody> GetSource => () => this;

        public ClassBody(IGenerator generator, IFactory<IFluentLink<IClassBody>> factory)
            : base(generator, factory)
        {
        }

        public IClass End()
        {
            Data = Generator.Generate(PatternConfig.ClassBodyPattern);
            Source.Invoke().Generator.AddGenerationData(typeof(IClassBody), Data);
            return Source.Invoke();
        }

        public IField WithField() => WithObject<IField>();
        public IProperty<IClassBody> WithProperty() => WithObject<IProperty<IClassBody>>();
        public IMethod<IClassBody> WithMethod() => WithObject<IMethod<IClassBody>>();
        public IClassBody WithFields(SequenceGenerator<IField> sequenceGenerator) => WithMultipleObjects(sequenceGenerator);
        public IClassBody WithProperties(SequenceGenerator<IProperty<IClassBody>> sequenceGenerator) => WithMultipleObjects(sequenceGenerator);
        public IClassBody WithMethods(SequenceGenerator<IMethod<IClassBody>> sequenceGenerator) => WithMultipleObjects(sequenceGenerator);
    }
}