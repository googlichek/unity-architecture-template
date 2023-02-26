namespace Game.Scripts.Core
{
    public class PooledTickerBehaviour : TickerBehaviour, IPoolItem
    {
        protected BasePoolComponent pool;

        public void Setup(BasePoolComponent owningPool)
        {
            pool = owningPool;
        }

        public void ReleaseSelf()
        {
            pool.Release(this);
        }
    }
}