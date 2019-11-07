using System;
using FluentGeneration.Shared;

namespace FluentGeneration.Interfaces.Interface
{
    public interface IInterfaceInheritance : IFluentLink<IInterface>
    {
        IInterfaceBody WithInheritance(params Type[] types);
        IInterfaceBody WithInheritance(string literal);
    }
}