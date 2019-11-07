using System;
using FluentGeneration.Shared;

namespace FluentGeneration.Interfaces.Class
{
    public interface IClassInheritance<T> : IFluentLink<T>
        where T : IGeneratedObject
    {
        IClassBody<T> WithInheritance(params Type[] types);
        IClassBody<T> WithInheritance(string literal);
    }
}