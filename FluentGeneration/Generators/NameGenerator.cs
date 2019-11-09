using System;

namespace FluentGeneration.Generators
{
    public class NameGenerator : IGeneratableHandler
    {
        public string Generate(GenerationData data)
        {
            if (data == null) { return string.Empty; }
            if (!(data.Data is string name)) { throw new InvalidOperationException($"{nameof(data)} contains invalid data!"); }

            return name;
        }
    }
}