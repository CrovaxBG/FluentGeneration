using FluentGeneration.Interfaces.Method;
using FluentGeneration.Interfaces.Property;
using FluentGeneration.Shared;

namespace FluentGeneration.Interfaces.Interface
{
    public interface IInterfaceBody : IGeneratedObject, IFluentLink<IInterface>, IEndable<IInterface>
    {
        IProperty<IInterfaceBody> WithProperty();
        IMethod<IInterfaceBody> WithMethod();

        IInterfaceBody WithProperties(SequenceGenerator<IProperty<IInterfaceBody>> sequenceGenerator);
        IInterfaceBody WithMethods(SequenceGenerator<IMethod<IInterfaceBody>> sequenceGenerator);
    }
}