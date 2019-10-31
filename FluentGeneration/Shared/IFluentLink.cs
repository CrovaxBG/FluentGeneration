using System;

namespace FluentGeneration.Shared
{
    public interface IFluentLink<T>
        where T : IGeneratedObject
    {
        Func<T> Source { get; set; }
    }
}