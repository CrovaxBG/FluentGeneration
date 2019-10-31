using FluentGeneration.Shared;

namespace FluentGeneration.Interfaces.Property
{
    public interface IPropertyValue<T> : IFluentLink<T>
        where T : IGeneratedObject
    {
        T WithNoValue();
        T WithPropertyValue(string value);
    }
}