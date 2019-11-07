namespace FluentGeneration.Generators
{
    public class RawStringDataGenerator : IGeneratableHandler
    {
        public string Generate(GenerationData data)
        {
            return (string)data.Data;
        }
    }
}