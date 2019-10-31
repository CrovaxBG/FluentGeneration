using System;
using FluentGeneration.Containers;
using FluentGeneration.Generators;

namespace FluentGeneration.Resolvers
{
    public class PatternResolver : IPatternResolver
    {
        private readonly IPatternContainer _container;

        public PatternResolver(IPatternContainer container)
        {
            _container = container;
        }

        public IGeneratableHandler Resolve(Type type)
        {
            return _container.Resolve(type);
        }
    }
}