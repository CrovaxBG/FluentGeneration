using System;
using System.Linq;
using FluentGeneration.Extensions;

namespace FluentGeneration.Generators
{
    public class AttributeGenerator : IGeneratableHandler
    {
        public string Generate(object data)
        {
            if (data == null) { throw new ArgumentNullException(nameof(data)); }
            if (data is string literal) { return literal; }
            if(!(data is Type[] types)) { throw new InvalidOperationException($"{nameof(data)} contains invalid data!"); }

            var attributes = types.Select(type => $"[{type.FormatTypeName()}]");
            return string.Join(Environment.NewLine, attributes);
        }
    }
}