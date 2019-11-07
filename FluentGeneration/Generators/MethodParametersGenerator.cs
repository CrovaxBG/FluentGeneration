using System;
using System.Collections.Generic;
using System.Linq;
using FluentGeneration.Extensions;
using FluentGeneration.Shared;

namespace FluentGeneration.Generators
{
    public class MethodParametersGenerator : IGeneratableHandler
    {
        private static readonly Dictionary<ParameterModifier, string> ModifierMap =
            new Dictionary<ParameterModifier, string>
            {
                [ParameterModifier.Standard] = string.Empty,
                [ParameterModifier.Ref] = "ref",
                [ParameterModifier.Out] = "out",
            };

        public string Generate(GenerationData data)
        {
            if (data == null) { throw new ArgumentNullException(nameof(data)); }
            if(data.Data is string literal) { return literal; }
            if (!(data.Data is IParameter[] parameters)) { throw new InvalidOperationException($"{nameof(data)} contains invalid data!"); }

            if (parameters.Length == 0) { return string.Empty; }

            return string.Join(", ", parameters.Select(Convert));
        }

        private string Convert(IParameter parameter)
        {
            var attributes = string.Join(string.Empty,
                parameter.ParameterAttributes.Select(att => att.FormatTypeName()));
            var modifier = ModifierMap[parameter.ParameterModifier];
            var type = parameter.ParameterType.FormatTypeName();
            var name = parameter.ParameterName;
            var sections = new[] {attributes, modifier, type, name};
            var output = sections.Where(section => !string.IsNullOrEmpty(section))
                .Aggregate(string.Empty, (current, section) => current + section + " ");
            return output.TrimEnd(' ');
        }
    }
}