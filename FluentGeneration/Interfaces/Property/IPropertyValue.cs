namespace FluentGeneration.Interfaces.Property
{
    public interface IPropertyValue<out T>
    {
        T WithNoValue();
        T WithPropertyValue(string value);
    }
}