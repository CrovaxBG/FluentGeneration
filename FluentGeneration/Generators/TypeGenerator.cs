using System;
using FluentGeneration.Extensions;

namespace FluentGeneration.Generators
{
    public class TypeGenerator : IGeneratableHandler
    {
        public string Generate(GenerationData data)
        {
            var type = (Type)data.Data;
            return type.FormatTypeName();
        }
    }
}