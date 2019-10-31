using FluentGeneration.Shared;

namespace FluentGeneration.Interfaces.Property
{
    public interface IPropertyName<T> : IFluentLink<T>
        where T : IGeneratedObject
    {
        IPropertyAttribute<T> WithName(string name);
    }
}