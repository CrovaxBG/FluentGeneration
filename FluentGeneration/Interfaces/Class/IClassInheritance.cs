using System;
using FluentGeneration.Shared;

namespace FluentGeneration.Interfaces.Class
{
    public interface IClassInheritance : IFluentLink<IClass>
    {
        IClassBody WithInheritance(params Type[] types);
        IClassBody WithInheritance(string literal);
    }
}