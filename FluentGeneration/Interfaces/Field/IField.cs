using FluentGeneration.Interfaces.Class;
using FluentGeneration.Shared;

namespace FluentGeneration.Interfaces.Field
{
    public interface IField :
        IGeneratedObject, IFluentLink<IClassBody>,
        IBeginable<IFieldAccessSpecifier>, IEndable<IClassBody>
    {
    }
}
