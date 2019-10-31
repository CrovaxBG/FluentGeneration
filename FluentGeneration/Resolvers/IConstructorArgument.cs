namespace FluentGeneration.Resolvers
{
    public interface IConstructorArgument
    {
        string Name { get; }
        object Value { get; }
    }
}