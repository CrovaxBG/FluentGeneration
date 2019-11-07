using System;
using System.Linq;
using FluentGeneration.Extensions;

namespace FluentGeneration.Generators
{
    public class AttributeGenerator : IGeneratableHandler
    {
        public string Generate(GenerationData data)
        {
            if (data.Data is string literal)
            {
                return literal;
            }

            var attributes = ((Type[])data.Data).Select(type => $"[{type.FormatTypeName()}]");
            return string.Join(Environment.NewLine, attributes);
        }
    }
}