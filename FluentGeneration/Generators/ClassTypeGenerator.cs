using System;
using System.Collections.Generic;
using FluentGeneration.Shared;

namespace FluentGeneration.Generators
{
    public class ClassTypeGenerator : IGeneratableHandler
    {
        private static readonly Dictionary<ClassType, string> SpecifiersMap =
            new Dictionary<ClassType, string>
            {
                [ClassType.Standard] = string.Empty,
                [ClassType.Static] = "static",
                [ClassType.Abstract] = "abstract",
                [ClassType.Sealed] = "sealed",
            };

        public string Generate(object data)
        {
            if (data == null) { throw new ArgumentNullException(nameof(data)); }
            if (!(data is ClassType classType)) { throw new InvalidOperationException($"{nameof(data)} contains invalid data!"); }

            return SpecifiersMap[classType];
        }
    }
}