namespace Prototype.Domain.Abstractions
{
    public interface IPrototype<T>
    {
        T Clone();
    }
}