using System;
using FluentGeneration.Generators;

namespace FluentGeneration.Resolvers
{
    public interface IPatternResolver
    {
        IGeneratableHandler Resolve(Type type);
    }
}
