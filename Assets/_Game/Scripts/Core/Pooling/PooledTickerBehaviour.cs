namespace Game.Scripts.Core
{
    public class PooledTickerBehaviour : TickerBehaviour, IPoolItem<PooledTickerBehaviour>
    {
        protected BasePoolComponent<PooledTickerBehaviour> pool;

        public void Setup(BasePoolComponent<PooledTickerBehaviour> owningPool)
        {
            pool = owningPool;
        }

        public void ReleaseSelf()
        {
            pool.Release(this);
        }
    }
}