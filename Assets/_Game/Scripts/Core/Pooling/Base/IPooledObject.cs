namespace Game.Scripts.Core
{
    public interface IPooledObject<T>
    {
        void Setup(IBasePool<T> basePool);
    }
}
