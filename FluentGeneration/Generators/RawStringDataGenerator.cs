using System;

namespace FluentGeneration.Generators
{
    public class RawStringDataGenerator : IGeneratableHandler
    {
        public string Generate(GenerationData data)
        {
            if (data == null) { throw new ArgumentNullException(nameof(data)); }
            if (!(data.Data is string raw)) { throw new InvalidOperationException($"{nameof(data)} contains invalid data!"); }

            return raw;
        }
    }
}