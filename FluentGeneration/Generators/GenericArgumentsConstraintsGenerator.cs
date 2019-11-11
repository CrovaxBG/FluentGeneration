using System;
using System.Linq;
using FluentGeneration.Extensions;
using FluentGeneration.Shared;

namespace FluentGeneration.Generators
{
    public class GenericArgumentsConstraintsGenerator : IGeneratableHandler
    {
        public string Generate(object data)
        {
            if (data == null) { throw new ArgumentNullException(nameof(data)); }
            if (data is string literal) { return literal; }
            if (!(data is IGenericArgumentConstraint[] arguments)) { throw new InvalidOperationException($"{nameof(data)} contains invalid data!"); }
            if(arguments.Any() && arguments.Any(arg => arg.Constraints == null || !arg.Constraints.Any())) { throw new InvalidOperationException($"{nameof(data)} contains arguments without constraints!");}
            
            return string.Join(Environment.NewLine,
                arguments.Select(arg =>
                    $"where {arg.GenericArgumentName} : {string.Join(", ", arg.Constraints.Select(t => t.FormatTypeName()))}"));
        }
    }
}