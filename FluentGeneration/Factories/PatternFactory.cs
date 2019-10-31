using System;
using FluentGeneration.Containers;
using FluentGeneration.Generators;

namespace FluentGeneration.Factories
{
    public class PatternFactory : IFactory<IGeneratableHandler>
    {
        protected readonly IPatternContainer Container;

        public PatternFactory(IPatternContainer container)
        {
            Container = container;
        }

        public virtual IGeneratableHandler Create(Type type)
        {
            return Container.Resolve(type);
        }
    }
}