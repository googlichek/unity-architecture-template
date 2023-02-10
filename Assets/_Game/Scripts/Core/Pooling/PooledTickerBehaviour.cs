namespace Game.Scripts.Core
{
    public class PooledTickerBehaviour : TickerBehaviour, ISelfReleasingFromPool<PooledTickerBehaviour>
    {
        protected IBasePoolRelease<PooledTickerBehaviour> _poolRelease = default;

        public void Setup(IBasePoolRelease<PooledTickerBehaviour> basePoolRelease)
        {
            _poolRelease = basePoolRelease;
        }

        public void ReleaseSelf()
        {
            _poolRelease.Release(this);
        }
    }
}
