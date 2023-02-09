namespace Game.Scripts.Core
{
    public class PooledTickerBehaviour : TickerBehaviour, IPooledObject<PooledTickerBehaviour>
    {
        protected IBasePool<PooledTickerBehaviour> pool = default;

        public void Setup(IBasePool<PooledTickerBehaviour> basePool)
        {
            pool = basePool;
        }
    }
}