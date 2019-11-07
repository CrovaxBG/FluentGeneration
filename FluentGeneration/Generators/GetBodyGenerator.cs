using FluentGeneration.Shared;

namespace FluentGeneration.Generators
{
    public class GetBodyGenerator : IGeneratableHandler
    {
        public string Generate(GenerationData data)
        {
            var bodyData = (BodyData) data.Data;
            if (bodyData.IsAuto)
            {
                return "get;";
            }

            return $@"get
    {{
       {bodyData.Body}
    }}";
        }
    }
}