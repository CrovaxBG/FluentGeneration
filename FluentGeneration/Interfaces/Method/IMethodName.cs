namespace FluentGeneration.Interfaces.Method
{
    public interface IMethodName<out T>
    {
        IMethodAttribute<T> WithName(string name);
    }
}