using System;

namespace FluentGeneration.Shared
{
    public interface IFluentLink<T>
    {
        Func<T> Source { get; set; }
    }
}