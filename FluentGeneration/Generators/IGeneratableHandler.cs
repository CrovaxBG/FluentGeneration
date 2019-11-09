using System.Diagnostics.Contracts;

namespace FluentGeneration.Generators
{
    public interface IGeneratableHandler
    {
        [Pure]
        string Generate(object data);
    }
}