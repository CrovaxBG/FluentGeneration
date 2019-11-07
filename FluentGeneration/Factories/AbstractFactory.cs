using System;
using Unity;

namespace FluentGeneration.Factories
{
    public class AbstractFactory<T> : IFactory<T>
    {
        protected readonly IUnityContainer Container;

        public AbstractFactory(IUnityContainer container)
        {
            Container = container ?? throw new ArgumentNullException(nameof(container));
        }

        public T Create(Type type)
        {
            if(type == null) { throw new ArgumentNullException(nameof(type)); }

            return (T) Container.Resolve(type);
        }
    }
}