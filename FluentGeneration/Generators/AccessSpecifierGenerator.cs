using System.Collections.Generic;
using FluentGeneration.Shared;

namespace FluentGeneration.Generators
{
    public class AccessSpecifierGenerator : IGeneratableHandler
    {
        private static readonly Dictionary<AccessSpecifier, string> SpecifiersMap =
            new Dictionary<AccessSpecifier, string>
            {
                [AccessSpecifier.None] = string.Empty,
                [AccessSpecifier.Private] = "private",
                [AccessSpecifier.Protected] = "protected",
                [AccessSpecifier.ProtectedInternal] = "protected internal",
                [AccessSpecifier.Internal] = "internal",
                [AccessSpecifier.Public] = "public"
            };

        public string Generate(GenerationData data)
        {
            var accessSpecifier = (AccessSpecifier) data.Data;
            return SpecifiersMap[accessSpecifier];
        }
    }
}