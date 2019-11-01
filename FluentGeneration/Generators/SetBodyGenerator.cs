using FluentGeneration.Shared;

namespace FluentGeneration.Generators
{
    public class SetBodyGenerator : IGeneratableHandler
    {
        public string Generate(GenerationData data)
        {
            var bodyData = (BodyData) data.Data;
            if (bodyData.IsAuto)
            {
                return "set;";
            }

            return $@"set
     {{
        {bodyData.Body}
     }}";
        }
    }
}