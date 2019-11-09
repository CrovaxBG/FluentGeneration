using System;
using System.Collections.Generic;
using FluentGeneration.Interfaces.Field;
using FluentGeneration.Interfaces.Method;
using FluentGeneration.Interfaces.Property;
using FluentGeneration.Shared;

namespace FluentGeneration.Interfaces.Class
{
    public interface IClassBody : IGeneratedObject, IFluentLink<IClass>, IEndable<IClass>
    {
        IField WithField();
        IProperty<IClassBody> WithProperty();
        IMethod<IClassBody> WithMethod();

        IClassBody WithFields(SequenceGenerator<IField> sequenceGenerator);
        IClassBody WithProperties(SequenceGenerator<IProperty<IClassBody>> sequenceGenerator);
        IClassBody WithMethods(SequenceGenerator<IMethod<IClassBody>> sequenceGenerator);
    }
}