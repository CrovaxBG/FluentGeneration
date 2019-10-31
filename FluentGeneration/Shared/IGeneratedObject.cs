using FluentGeneration.Generators;

namespace FluentGeneration.Shared
{
    public interface IGeneratedObject
    {
        IGenerator Generator { get; }
        string Data { get; }
    }
}