namespace FluentGeneration.Shared
{
    public interface IEndable<out T>
    {
        T End();
    }
}