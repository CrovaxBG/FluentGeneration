using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using FluentGeneration.Extensions;
using FluentGeneration.Factories;

namespace FluentGeneration.Generators
{
    public class CodeGenerator : IGenerator
    {
        protected Dictionary<Type, object> GenerationData;

        private const string TypePattern = @"\[(.*?)\]";

        private readonly IFactory<IGeneratableHandler> _factory;

        public CodeGenerator(IFactory<IGeneratableHandler> factory)
        {
            _factory = factory;
            GenerationData = new Dictionary<Type, object>();
        }

        public string Generate(string pattern)
        {
            var typeTokens = ExtractTypeTokens(pattern);

            var filteredTokens = VerifyTypeTokens(typeTokens);

            foreach (var data in GenerationData.Where(data => filteredTokens.Contains(data.Key.FormatTypeName(false))))
            {
                pattern = ReplaceTypeToken(pattern, new GenerationData(data.Key, data.Value));
                filteredTokens.Remove(data.Key.FormatTypeName(false));
            }

            return filteredTokens.Aggregate(pattern, ClearSection);
        }

        private IEnumerable<string> ExtractTypeTokens(string pattern)
        {
            return Regex.Matches(pattern, TypePattern, RegexOptions.IgnoreCase)
                .Select(m => m.Groups[1].Value);
        }

        private HashSet<string> VerifyTypeTokens(IEnumerable<string> typeTokens)
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

        private string ReplaceTypeToken(string currentCode, GenerationData data)
        {
            var instance = _factory.Create(data.Type);
            var generatedCode = instance.Generate(data);
            var typeToken = $"[{data.Type.FormatTypeName(false)}]";

            currentCode = RemoveSection(currentCode, typeToken);

            return currentCode.Replace(typeToken, generatedCode);
        }

        private string RemoveSection(string currentCode, string typeToken)
        {
            var builder = new StringBuilder(currentCode);
            var indexOfToken = currentCode.IndexOf(typeToken, StringComparison.Ordinal);

            var sectionOpeningIndex = currentCode.LastIndexOf('{', indexOfToken);
            var sectionClosingIndex = currentCode.IndexOf('}', indexOfToken - 1);

            builder.Remove(sectionOpeningIndex, 1);
            builder.Remove(sectionClosingIndex - 1, 1);

            return builder.ToString();
        }

        private string ClearSection(string currentCode, string typeToken)
        {
            var pattern = @"\{[^{}]*\[([" + typeToken + @"]+)\][^{}]*\} "; //removes 1 extra space
            var matches = Regex.Match(currentCode, pattern);
            if (!matches.Success)
            {
                pattern = @"\{[^{}]*\[([" + typeToken + @"]+)\][^{}]*\}";//works only for last section
            }
            return Regex.Replace(currentCode, pattern, string.Empty);
        }

        public virtual void AddGenerationData(Type type, object data)
        {
            if (type == null) { return; }

            if (GenerationData.ContainsKey(type))
            {
                return;
            }

            GenerationData.Add(type, data);
        }
    }
}