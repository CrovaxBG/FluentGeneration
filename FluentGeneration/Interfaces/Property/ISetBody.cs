using FluentGeneration.Shared;

namespace FluentGeneration.Interfaces.Property
{
    public interface ISetBody<T> : IFluentLink<T>
        where T : IGeneratedObject
    {
        IPropertyValue<T> NoSet();
        IPropertyValue<T> AutoSet();
        IPropertyValue<T> WithSetBody(string body);
    }
}