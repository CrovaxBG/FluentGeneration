using System;
using System.Collections.Generic;
using System.Linq;
using FluentGeneration.Extensions;
using FluentGeneration.Factories;

namespace FluentGeneration.Generators
{
    public class SingleValueCodeGenerator : BaseGenerator
    {
        protected Dictionary<Type, object> GenerationData;

        public override bool IsEmpty => !GenerationData.Any();

        private readonly IFactory<IGeneratableHandler> _factory;

        public SingleValueCodeGenerator(IFactory<IGeneratableHandler> factory)
        {
            _factory = factory ?? throw new ArgumentNullException(nameof(factory));
            GenerationData = new Dictionary<Type, object>();
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
            var instance = _factory.Create(data.Type);
            var generatedCode = instance.Generate(data.Data);
            var typeToken = $"[{data.Type.FormatTypeName(false)}]";

            currentCode = RemoveSection(currentCode, typeToken);

            return currentCode.Replace(typeToken, generatedCode);
        }

        public override void AddGenerationData(Type type, object data)
        {
            if (type == null) { throw new ArgumentNullException(nameof(type)); }

            if (GenerationData.ContainsKey(type))
            {
                return;
            }

            GenerationData.Add(type, data);
        }
    }
}