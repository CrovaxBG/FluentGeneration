using System;
using System.Linq;
using FluentGeneration.Extensions;

namespace FluentGeneration.Generators
{
    public class InheritanceGenerator : IGeneratableHandler
    {
        public string Generate(object data)
        {
            if (data == null) { throw new ArgumentNullException(nameof(data)); }
            if (data is string literal) { return literal; }
            if (!(data is Type[] inheritedTypes)) { throw new InvalidOperationException($"{nameof(data)} contains invalid data!"); }

            return string.Join(", ", inheritedTypes.Select(type => type.FormatTypeName()));
        }
    }
}