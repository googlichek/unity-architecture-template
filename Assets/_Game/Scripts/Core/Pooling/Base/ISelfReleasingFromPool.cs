namespace Game.Scripts.Core
{
    public interface ISelfReleasingFromPool<T>
    {
        void Setup(IBasePoolRelease<T> basePoolRelease);

        void ReleaseSelf();
    }
}
