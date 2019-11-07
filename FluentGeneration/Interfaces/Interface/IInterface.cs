﻿using FluentGeneration.Interfaces.Class;
using FluentGeneration.Shared;

namespace FluentGeneration.Interfaces.Interface
{
    public interface IInterface : IGeneratedObject, IFluentLink<IFile>, IEndable<IFile>,
        IBeginable<IInterfaceAccessSpecifier<IInterface>>
    {

    }
}
