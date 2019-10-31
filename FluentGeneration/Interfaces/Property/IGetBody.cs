namespace FluentGeneration.Interfaces.Property
{
    public interface IGetBody<out T>
    {
        ISetAccessSpecifier<T> AutoGet();
        ISetAccessSpecifier<T> WithGetBody(string body);
    }
}