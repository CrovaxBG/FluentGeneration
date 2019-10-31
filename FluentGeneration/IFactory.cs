using System;
using Unity;

namespace FluentGeneration
{
    public interface IFactory<out T>
    {
        T Create(Type type);
    }

    public class AbstractFactory<T> : IFactory<T>
    {
        protected readonly IUnityContainer Container;

        public AbstractFactory(IUnityContainer container)
        {
            Container = container;
        }

        public T Create(Type type)
        {
            return (T)Container.Resolve(type);
        }
    }

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