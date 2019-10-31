using System;
using FluentGeneration.Generators;
using FluentGeneration.Resolvers;

namespace FluentGeneration.Containers
{
    public interface IPatternContainer : IPatternResolver, IDisposable
    {
        IPatternContainer RegisterType(Type registeredType, Type mappedToType);
        IPatternContainer RegisterType<TFrom, TTo>() where TTo : IGeneratableHandler;
        bool IsRegistered(Type type);
    }
}
