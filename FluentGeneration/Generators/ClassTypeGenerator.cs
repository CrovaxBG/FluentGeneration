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

        public string Generate(GenerationData data)
        {
            var classType = (ClassType) data.Data;
            return SpecifiersMap[classType];
        }
    }
}