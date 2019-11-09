namespace FluentGeneration.Generators
{
    public class ValueGenerator : IGeneratableHandler
    {
        public string Generate(object data)
        {
            return data == null ? "null" : data.ToString();
        }
    }
}