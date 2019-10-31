using System;
using System.Linq;

namespace FluentGeneration.Extensions
{
    public static class TypeExtensions
    {
        public static string FormatTypeName(this Type type, bool fullyQualified)
        {
            if (type == null) { throw new ArgumentNullException(nameof(type)); }

            var typeName = FormatTypeName(type);

            if (!fullyQualified)
            {
                return typeName.Substring(typeName.LastIndexOf('.') + 1);
            }

            return typeName;
        }

        public static string FormatTypeName(this Type type)
        {
            if (type == null) { throw new ArgumentNullException(nameof(type)); }

            if (type.IsGenericType)
            {
                var definedArguments = type.GetGenericArguments();
                var genericIdentifier = $"`{definedArguments.Length}";

                if (definedArguments.First().FullName == null)
                {
                    var genericBraces = "<".PadRight(definedArguments.Length, ',') + ">";
                    return $"{type.Namespace}.{type.Name.Replace(genericIdentifier, genericBraces)}";
                }

                var formattedTypes = definedArguments.Select(definedArgument => definedArgument.FormatTypeName());

                var newGenericArguments = $"<{string.Join(", ", formattedTypes)}>";
                return $"{type.Namespace}.{type.Name.Replace(genericIdentifier, newGenericArguments, StringComparison.InvariantCultureIgnoreCase)}";
            }

            return $"{type.Namespace}.{type.Name}";
        }
    }
}
