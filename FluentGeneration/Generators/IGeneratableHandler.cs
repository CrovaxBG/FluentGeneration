namespace FluentGeneration.Generators
{
    public interface IGeneratableHandler
    {
        string Generate(GenerationData data);
    }
}