namespace FluentGeneration.Generators
{
    public class ValueGenerator : IGeneratableHandler
    {
        public string Generate(GenerationData data)
        {
            return data.Data == null ? "null" : data.Data.ToString();
        }
    }
}