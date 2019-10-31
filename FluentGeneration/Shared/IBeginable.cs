namespace FluentGeneration.Shared
{
    public interface IBeginable<out T>
    {
        T Begin();
    }
}