using System;

namespace FluentGeneration.Generators
{
    public class NamespaceGenerator : IGeneratableHandler
    {
        public string Generate(object data)
        {
            if (data == null) { throw new ArgumentNullException(nameof(data)); }
            if (!(data is string name)) { throw new InvalidOperationException($"{nameof(data)} contains invalid data!"); }

            return $"namespace {name}";
        }
    }
}