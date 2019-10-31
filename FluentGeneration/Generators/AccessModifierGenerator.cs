﻿using System.Collections.Generic;
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
            var accessModifiers = ((AccessModifiers)data.Data).ToString().Replace(",", string.Empty).Split(' ');
            return accessModifiers.Aggregate(string.Empty, (current, modifier) => current + " " + ModifiersMap[modifier]);
        }
    }
}