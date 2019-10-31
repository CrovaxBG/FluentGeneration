using System;
using Unity;

namespace FluentGeneration
{
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
}