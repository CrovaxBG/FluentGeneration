using System;
using FluentGeneration.Extensions;

namespace FluentGeneration.Generators
{
    public class TypeGenerator : IGeneratableHandler
    {
        public string Generate(object data)
        {
            if (data == null) { throw new ArgumentNullException(nameof(data)); }
            if(data is string literal) { return literal; }
            if (!(data is Type type)) { throw new InvalidOperationException($"{nameof(data)} contains invalid data!"); }

            if (type == typeof(void)) { return "void"; }

            return type.FormatTypeName();
        }
    }
}