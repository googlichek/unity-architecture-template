namespace Game.Scripts.Core
{
    public interface IPool<T>
    {
        T Get();

        void Release(T instance);
    }
}