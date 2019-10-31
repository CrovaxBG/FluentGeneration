using FluentGeneration.Shared;

namespace FluentGeneration.Interfaces.Field
{
    public interface IFieldValue<T> : IFluentLink<T>
        where T : IGeneratedObject
    {
        T WithNoValue();
        T WithValue(object value);
    }
}