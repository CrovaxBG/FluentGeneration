using System;
using FluentGeneration.Generators;
using FluentGeneration.Interfaces.Field;
using FluentGeneration.Shared;

namespace FluentGeneration.Implementations.Field
{
    public class Field<T> : IField<T>
        where T : IGeneratedObject
    {
        public IGenerator Generator { get; }
        public string Data { get; private set; }
        public Func<T> Source { get; set; }

        private readonly IFieldAccessSpecifier<IField<T>> _accessSpecifier;

        public Field(IGenerator generator, IFieldAccessSpecifier<IField<T>> accessSpecifier)
        {
            Generator = generator;
            _accessSpecifier = accessSpecifier;
            _accessSpecifier.Source = () => this;
        }

        public IFieldAccessSpecifier<IField<T>> Begin()
        {
            return _accessSpecifier;
        }

        public T End()
        {
            Data = Generator.Generate(PatternConfig.FieldPattern);
            Source.Invoke().Generator.AddGenerationData(typeof(IField<>), Data);
            Console.WriteLine(Data);
            Console.ReadKey();
            return Source.Invoke();
        }
    }
}
