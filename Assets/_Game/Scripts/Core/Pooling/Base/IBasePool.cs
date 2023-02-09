namespace Game.Scripts.Core
{
    public interface IBasePool<T>
    {
        public T Get();

        public void Release(T instance);
    }
}
