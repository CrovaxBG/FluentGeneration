namespace FluentGeneration.Interfaces.Property
{
    public interface IPropertyName<out T>
    {
        IPropertyAttribute<T> WithName(string name);
    }
}