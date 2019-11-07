using System;
using System.Linq;
using FluentGeneration.Extensions;
using FluentGeneration.Shared;

namespace FluentGeneration.Generators
{
    public class GenericArgumentsConstraintsGenerator : IGeneratableHandler
    {
        public string Generate(GenerationData data)
        {
            if (data.Data is string literal)
            {
                return literal;
            }
            var arguments = (IGenericArgumentConstraint[])data.Data;
            return string.Join(Environment.NewLine + "".PadRight(4,' '),
                arguments.Select(arg =>
                    $"where {arg.GenericArgumentName} : {string.Join(", ", arg.Constraints.Select(t => TypeExtensions.FormatTypeName(t)))}"));
        }
    }
}