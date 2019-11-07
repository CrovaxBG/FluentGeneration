using System.Collections.Generic;
using System.Linq;
using FluentGeneration.Shared;

namespace FluentGeneration.Generators
{
    public class GenericArgumentsGenerator : IGeneratableHandler
    {
        private static readonly Dictionary<GenericArgumentType, string> _typesMap =
            new Dictionary<GenericArgumentType, string>
            {
                [GenericArgumentType.Standard] = string.Empty,
                [GenericArgumentType.Covariant] = "out",
                [GenericArgumentType.Contravariant] = "in",
            };

        public string Generate(GenerationData data)
        {
            var arguments = (IGenericArgument[]) data.Data;
            return string.Join(", ",
                arguments.Select(arg =>
                    $"{_typesMap[arg.Type] + (arg.Type == GenericArgumentType.Standard ? string.Empty : " ")}{arg.Name}"));
        }
    }
}