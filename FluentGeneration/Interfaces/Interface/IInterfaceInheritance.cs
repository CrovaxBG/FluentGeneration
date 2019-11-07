using System;
using FluentGeneration.Shared;

namespace FluentGeneration.Interfaces.Interface
{
    public interface IInterfaceInheritance<T> : IFluentLink<T>
        where T : IGeneratedObject
    {
        IInterfaceBody<T> WithInheritance(params Type[] types);
        IInterfaceBody<T> WithInheritance(string literal);
    }
}