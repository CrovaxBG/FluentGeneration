using System;
using FluentGeneration.Shared;

namespace FluentGeneration.Interfaces.Class
{
    public interface IClassInheritance<T> : IFluentLink<T>
        where T : IGeneratedObject
    {
        IClassBody<T> WithClassInheritance(params Type[] types);
        IClassBody<T> WithClassInheritance(string literal);
    }
}