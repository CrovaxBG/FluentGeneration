﻿using System;

namespace FluentGeneration.Generators
{
    public class NameGenerator : IGeneratableHandler
    {
        public string Generate(GenerationData data)
        {
            if (data == null) { throw new ArgumentNullException(nameof(data)); }
            if (!(data.Data is string name)) { throw new InvalidOperationException($"{nameof(data)} contains invalid data!"); }

            return name;
        }
    }
}