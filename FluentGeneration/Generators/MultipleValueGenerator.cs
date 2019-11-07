using System;
using System.Collections.Generic;
using System.Linq;
using FluentGeneration.Extensions;

namespace FluentGeneration.Generators
{
    public class MultipleValueGenerator : BaseGenerator
    {
        protected Dictionary<Type, List<object>> GenerationData;

        public override bool IsEmpty => !GenerationData.Any();

        public MultipleValueGenerator()
        {
            GenerationData = new Dictionary<Type, List<object>>();
        }

        public override string Generate(string pattern)
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

        private string ReplaceTypeToken(string currentCode, GenerationData data)
        {
            var objectsData = (IEnumerable<object>) data.Data;
            var generatedCode = string.Join(string.Empty,
                objectsData.Select(o => $"{(string) o}{Environment.NewLine}"));
            var typeToken = $"[{data.Type.FormatTypeName(false)}]";

            currentCode = RemoveSection(currentCode, typeToken);

            return currentCode.Replace(typeToken, generatedCode);
        }

        public override void AddGenerationData(Type type, object data)
        {
            if (type == null)
            {
                return;
            }

            if (GenerationData.TryGetValue(type, out var values))
            {
                values.Add(data);
            }
            else
            {
                GenerationData.Add(type, new List<object> {data});
            }
        }
    }
}