using UnityEngine;
using UnityEngine.Pool;
using Zenject;

namespace Game.Scripts.Core
{
    public abstract class BasePoolComponent : TickerComponent
    {
        private PooledTickerBehaviour _prefab = default;

        private ObjectPool<PooledTickerBehaviour> _pool = default;

        private DiContainer _diContainer = default;

        [Inject]
        void Construct(DiContainer diContainer)
        {
            _diContainer = diContainer;
        }

        public PooledTickerBehaviour Get()
        {
            return _pool.Get();
        }

        public void Release(PooledTickerBehaviour instance)
        {
            _pool.Release(instance);
        }

        protected void InitPool(
            PooledTickerBehaviour poolPrefab,
            Transform poolRoot = null,
            int initial = 10,
            int max = 20,
            bool collectionChecks = false)
        {
            _prefab = poolPrefab;

            _pool =
                new ObjectPool<PooledTickerBehaviour>(
                    () => CreateInstance(poolRoot),
                    GetInstance,
                    ReleaseInstance,
                    DestroyInstance,
                    collectionChecks,
                    initial,
                    max);
        }

        protected void DisposePool()
        {
            _pool.Dispose();
        }

        protected virtual PooledTickerBehaviour CreateInstance(Transform root)
        {
            var instance = _diContainer.InstantiatePrefabForComponent<PooledTickerBehaviour>(_prefab, root);
            instance.Setup(this);

            return instance;
        }

        protected virtual void GetInstance(PooledTickerBehaviour instance)
        {
            instance.gameObject.SetActive(true);
        }

        protected virtual void ReleaseInstance(PooledTickerBehaviour instance)
        {
            instance.gameObject.SetActive(false);
        }

        protected virtual void DestroyInstance(PooledTickerBehaviour instance)
        {
            Destroy(instance);
        }
    }
}
