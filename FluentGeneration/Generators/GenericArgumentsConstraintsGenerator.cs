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
            if (data == null) { throw new ArgumentNullException(nameof(data)); }
            if (data.Data is string literal) { return literal; }
            if (!(data.Data is IGenericArgumentConstraint[] arguments)) { throw new InvalidOperationException($"{nameof(data)} contains invalid data!"); }

            return string.Join(Environment.NewLine + "".PadRight(4,' '),
                arguments.Select(arg =>
                    $"where {arg.GenericArgumentName} : {string.Join(", ", arg.Constraints.Select(t => t.FormatTypeName()))}"));
        }
    }
}