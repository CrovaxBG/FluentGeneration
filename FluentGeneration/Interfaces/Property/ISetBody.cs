namespace FluentGeneration.Interfaces.Property
{
    public interface ISetBody<out T>
    {
        IPropertyValue<T> AutoSet();
        IPropertyValue<T> WithSetBody(string body);
    }
}