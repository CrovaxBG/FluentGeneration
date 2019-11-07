namespace FluentGeneration.Shared
{
    public class GenericArgument : IGenericArgument
    {
        public string Name { get; set; }
        public GenericArgumentType Type { get; set; }
    }
}