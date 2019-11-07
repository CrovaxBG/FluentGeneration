using FluentGeneration.Resolvers;

namespace FluentGeneration.Shared
{
    public class ConstructorArgument : IConstructorArgument
    {
        public string Name { get; set; }
        public object Value { get; set; }
    }
}