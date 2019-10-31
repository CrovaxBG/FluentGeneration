namespace FluentGeneration.Interfaces.Method
{
    public interface IMethodBody<out T>
    {
        T WithMethodBody(string body);
    }
}