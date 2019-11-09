using System;

namespace FluentGeneration.Generators
{
    public class NameGenerator : IGeneratableHandler
    {
        public string Generate(object data)
        {
            if (data == null) { return string.Empty; }
            if (!(data is string name)) { throw new InvalidOperationException($"{nameof(data)} contains invalid data!"); }

            return name;
        }
    }
}