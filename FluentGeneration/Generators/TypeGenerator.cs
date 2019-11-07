using System;
using FluentGeneration.Extensions;

namespace FluentGeneration.Generators
{
    public class TypeGenerator : IGeneratableHandler
    {
        public string Generate(GenerationData data)
        {
            if (data == null) { throw new ArgumentNullException(nameof(data)); }
            if (!(data.Data is Type type)) { throw new InvalidOperationException($"{nameof(data)} contains invalid data!"); }

            if (type == typeof(void)) { return "void"; }

            return type.FormatTypeName();
        }
    }
}