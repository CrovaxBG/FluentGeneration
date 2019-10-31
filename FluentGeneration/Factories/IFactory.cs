using System;

namespace FluentGeneration
{
    public interface IFactory<out T>
    {
        T Create(Type type);
    }
}