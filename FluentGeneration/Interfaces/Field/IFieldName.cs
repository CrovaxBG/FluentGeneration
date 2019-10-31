using FluentGeneration.Shared;

namespace FluentGeneration.Interfaces.Field
{
    public interface IFieldName<T> : IFluentLink<T>
        where T : IGeneratedObject
    {
        IFieldAttribute<T> WithName(string name);
    }
}