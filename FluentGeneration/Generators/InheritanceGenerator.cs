using System;
using System.Linq;
using FluentGeneration.Extensions;

namespace FluentGeneration.Generators
{
    public class InheritanceGenerator : IGeneratableHandler
    {
        public string Generate(GenerationData data)
        {
            if (data == null) { throw new ArgumentNullException(nameof(data)); }
            if (data.Data is string literal) { return literal; }
            if (!(data.Data is Type[] inheritedTypes)) { throw new InvalidOperationException($"{nameof(data)} contains invalid data!"); }

            return string.Join(", ", inheritedTypes.Select(type => type.FormatTypeName()));
        }
    }
}