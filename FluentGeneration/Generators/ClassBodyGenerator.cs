namespace FluentGeneration.Generators
{
    public class ClassBodyGenerator : IGeneratableHandler
    {
        public string Generate(GenerationData data)
        {
            return (string)data.Data;
        }
    }
}