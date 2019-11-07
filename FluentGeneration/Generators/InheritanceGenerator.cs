using System;
using System.Linq;
using FluentGeneration.Extensions;

namespace FluentGeneration.Generators
{
    public class InheritanceGenerator : IGeneratableHandler
    {
        public string Generate(GenerationData data)
        {
            if (data.Data is string literal)
            {
                return literal;
            }
            var inheritedTypes = (Type[]) data.Data;
            return string.Join(", ", inheritedTypes.Select(type => type.FormatTypeName()));
        }
    }
}