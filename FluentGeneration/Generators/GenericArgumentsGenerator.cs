using System.Linq;
using FluentGeneration.Shared;

namespace FluentGeneration.Generators
{
    public class GenericArgumentsGenerator : IGeneratableHandler
    {
        public string Generate(GenerationData data)
        {
            var arguments = (IGenericArgument[]) data.Data;
            return string.Join(", ", arguments.Select(arg => arg.Name));
        }
    }
}