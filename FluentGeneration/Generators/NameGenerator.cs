namespace FluentGeneration.Generators
{
    public class NameGenerator : IGeneratableHandler
    {
        public string Generate(GenerationData data)
        {
            return (string)data.Data;
        }
    }
}