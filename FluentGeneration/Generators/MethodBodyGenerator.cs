using FluentGeneration.Shared;

namespace FluentGeneration.Generators
{
    public class MethodBodyGenerator : IGeneratableHandler
    {
        public string Generate(GenerationData data)
        {
            var bodyData = (BodyData) data.Data;
            if (bodyData.IsAuto)
            {
                return ";";
            }

            return $@"
{{
    {bodyData.Body}
}}";
        }
    }
}