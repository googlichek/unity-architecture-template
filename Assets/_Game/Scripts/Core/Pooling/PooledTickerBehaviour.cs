namespace Game.Scripts.Core
{
    public class PooledTickerBehaviour : TickerBehaviour, IPoolItem<PooledTickerBehaviour>
    {
        protected IPool<PooledTickerBehaviour> pool;

        public void Setup(IPool<PooledTickerBehaviour> owningPool)
        {
            pool = owningPool;
        }

        public void ReleaseSelf()
        {
            pool.Release(this);
        }
    }
}