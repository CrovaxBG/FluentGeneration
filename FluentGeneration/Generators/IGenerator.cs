using System;
using System.Diagnostics.Contracts;

namespace FluentGeneration.Generators
{
    public interface IGenerator
    {
        [Pure]
        string Generate(string pattern);
        void AddGenerationData(Type type, object data);
        bool IsEmpty { get; }
    }
}
