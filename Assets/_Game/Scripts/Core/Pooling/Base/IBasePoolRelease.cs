namespace Game.Scripts.Core
{
    public interface IBasePoolRelease<T>
    {
        public void Release(T instance);
    }
}
