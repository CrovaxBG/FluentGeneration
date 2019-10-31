using System;

namespace FluentGeneration.Generators
{
    public interface IGenerator
    {
        string Generate(string pattern);
        void AddGenerationData(Type type, object data);
    }
}
