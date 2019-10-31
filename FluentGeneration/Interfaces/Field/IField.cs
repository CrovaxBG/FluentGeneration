using FluentGeneration.Shared;

namespace FluentGeneration.Interfaces.Field
{
    public interface IField<T> :
        IGeneratedObject, IFluentLink<T>,
        IBeginable<IFieldAccessSpecifier<IField<T>>>, IEndable<T>
        where T : IGeneratedObject
    {
    }
}
