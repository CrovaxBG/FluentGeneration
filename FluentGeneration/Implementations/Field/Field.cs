﻿using System;
using FluentGeneration.Generators;
using FluentGeneration.Interfaces.Class;
using FluentGeneration.Interfaces.Field;

namespace FluentGeneration.Implementations.Field
{
    public class Field : IField
    {
        public IGenerator Generator { get; }
        public string Data { get; private set; }
        public Func<IClassBody> Source { get; set; }

        private readonly IFieldAccessSpecifier _accessSpecifier;

        public Field(IGenerator generator, IFieldAccessSpecifier accessSpecifier)
        {
            Generator = generator ?? throw new ArgumentNullException(nameof(generator));
            _accessSpecifier = accessSpecifier ?? throw new ArgumentNullException(nameof(accessSpecifier));
            _accessSpecifier.Source = () => this;
        }

        public IFieldAccessSpecifier Begin()
        {
            return _accessSpecifier;
        }

        public IClassBody End()
        {
            Data = Generator.Generate(PatternConfig.FieldPattern);
            Source.Invoke().Generator.AddGenerationData(typeof(IField), Data);
            return Source.Invoke();
        }
    }
}
