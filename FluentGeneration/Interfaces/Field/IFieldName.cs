using FluentGeneration.Interfaces.Class;
using FluentGeneration.Shared;

namespace FluentGeneration.Interfaces.Field
{
    public interface IFieldName : IFluentLink<IField>
    {
        IFieldAttribute WithName(string name);
    }
}