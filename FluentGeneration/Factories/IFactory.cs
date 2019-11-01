using System;

namespace FluentGeneration.Factories
{
    public interface IFactory<out T>
    {
        T Create(Type type);
    }
}