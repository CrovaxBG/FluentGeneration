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
            Container = container ?? throw new ArgumentNullException(nameof(container));
        }

        public virtual IGeneratableHandler Create(Type type)
        {
            if(type == null) { throw new ArgumentNullException(nameof(type)); }

            return Container.Resolve(type);
        }
    }
}