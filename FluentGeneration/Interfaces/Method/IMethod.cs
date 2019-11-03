using FluentGeneration.Shared;

namespace FluentGeneration.Interfaces.Method
{
    public interface IMethod<T> :
        IGeneratedObject, IFluentLink<T>,
        IBeginable<IMethodAccessSpecifier<IMethod<T>>>, IEndable<T>
        where T : IGeneratedObject
    {

    }
}
