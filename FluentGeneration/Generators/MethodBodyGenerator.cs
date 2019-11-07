using System;
using FluentGeneration.Shared;

namespace FluentGeneration.Generators
{
    public class MethodBodyGenerator : IGeneratableHandler
    {
        public string Generate(GenerationData data)
        {
            if (data == null) { throw new ArgumentNullException(nameof(data)); }
            if (!(data.Data is BodyData bodyData)) { throw new InvalidOperationException($"{nameof(data)} contains invalid data!"); }

            if (bodyData.IsAuto) { return ";"; }

            return $@"
{{
    {bodyData.Body}
}}";
        }
    }
}