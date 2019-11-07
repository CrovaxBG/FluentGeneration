using System;
using System.Collections.Generic;
using System.Diagnostics.Contracts;
using System.Linq;
using FluentGeneration.Shared;

namespace FluentGeneration.Generators
{
    public class AccessModifierGenerator : IGeneratableHandler
    {
        private static readonly Dictionary<string, string> ModifiersMap =
            new Dictionary<string, string>
            {
                [AccessModifiers.None.ToString()] = string.Empty,
                [AccessModifiers.Const.ToString()] = "const",
                [AccessModifiers.Readonly.ToString()] = "readonly",
                [AccessModifiers.Static.ToString()] = "static",
                [AccessModifiers.Volatile.ToString()] = "volatile",
            };


        public string Generate(GenerationData data)
        {
            if(data == null) { throw new ArgumentNullException(nameof(data)); }
            if (!(data.Data is AccessModifiers modifiers)) { throw new InvalidOperationException($"{nameof(data)} contains invalid data!");}

            var accessModifiers = modifiers.ToString().Replace(",", string.Empty)
                .Split(' ', StringSplitOptions.RemoveEmptyEntries);
            return string.Join(" ", accessModifiers.Select(m => ModifiersMap[m]));
        }
    }
}