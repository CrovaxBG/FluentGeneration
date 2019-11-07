using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;

namespace FluentGeneration.Generators
{
    public abstract class BaseGenerator : IGenerator
    {
        protected const string TypePattern = @"\[(.*?)\]";

        public abstract string Generate(string pattern);

        public abstract void AddGenerationData(Type type, object data);

        public virtual bool IsEmpty { get; protected set; }

        protected virtual IEnumerable<string> ExtractTypeTokens(string pattern)
        {
            return Regex.Matches(pattern, TypePattern, RegexOptions.IgnoreCase)
                .Select(m => m.Groups[1].Value);
        }

        protected virtual HashSet<string> VerifyTypeTokens(IEnumerable<string> typeTokens)
        {
            //Not using HashSet<string>(IEnumerable<> source) because we want to throw exception
            //if there are duplicates, this means there is problem in the pattern, and not just swallow it silently
            var filteredTokens = new HashSet<string>();
            if (typeTokens.Any(type => !filteredTokens.Add(type)))
            {
                throw new InvalidOperationException(@"Generated object pattern cannot contain duplicate types!");
            }

            return filteredTokens;
        }

        protected virtual string RemoveSection(string currentCode, string typeToken)
        {
            var builder = new StringBuilder(currentCode);
            var indexOfToken = currentCode.IndexOf(typeToken, StringComparison.Ordinal);

            var sectionOpeningIndex = currentCode.LastIndexOf('{', indexOfToken);
            var sectionClosingIndex = currentCode.IndexOf('}', indexOfToken - 1);

            builder.Remove(sectionOpeningIndex, 1);
            builder.Remove(sectionClosingIndex - 1, 1);

            return builder.ToString();
        }

        protected virtual string ClearSection(string currentCode, string typeToken)
        {
            var pattern = @"{[^{}]*\[([" + typeToken + @"]+)\][^{}]*\} "; //removes 1 extra space
            var matches = Regex.Match(currentCode, pattern);
            if (!matches.Success)
            {
                pattern = @"\{[^{}]*\[([" + typeToken + @"]+)\][^{}]*\}";//works only for last section
            }

            return Regex.Replace(currentCode, pattern, string.Empty);
        }
    }
}