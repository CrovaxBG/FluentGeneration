using System;
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

        public string Generate(object data)
        {
            if (data == null) { throw new ArgumentNullException(nameof(data)); }
            if (!(data is AccessSpecifier specifier)) { throw new InvalidOperationException($"{nameof(data)} contains invalid data!"); }

            return SpecifiersMap[specifier];
        }
    }
}