using FluentGeneration.Shared;

namespace FluentGeneration.Interfaces.Method
{
    public interface IMethod<out T> : IGeneratedObject, IEndable<T>,
        IMethodAccessSpecifier<IMethod<T>>, IMethodAccessModifier<IMethod<T>>, IMethodType<IMethod<T>>,
        IMethodName<IMethod<T>>, IMethodAttribute<IMethod<T>>, IMethodParameters<IMethod<T>>,
        IMethodBody<IMethod<T>>
    {

    }
}
