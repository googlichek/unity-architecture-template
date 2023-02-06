using UnityEngine;
using UnityEngine.Pool;
using Zenject;

namespace Game.Scripts.Core
{
    public abstract class BasePool<T> : TickerComponent where T : TickerBehaviour
    {
        private T _prefab = default;

        private ObjectPool<T> _pool = default;

        private DiContainer _diContainer = default;

        [Inject]
        void Construct(DiContainer diContainer)
        {
            _diContainer = diContainer;
        }

        public T Get()
        {
            return _pool.Get();
        }

        public void Release(T instance)
        {
            _pool.Release(instance);
        }

        protected void InitPool(
            T poolPrefab,
            Transform poolRoot = null,
            int initial = 10,
            int max = 20,
            bool collectionChecks = false)
        {
            _prefab = poolPrefab;

            _pool =
                new ObjectPool<T>(
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

        protected virtual T CreateInstance(Transform root)
        {
            var instance = _diContainer.InstantiatePrefabForComponent<T>(_prefab, root);
            return instance;
        }

        protected virtual void GetInstance(T instance)
        {
            instance.gameObject.SetActive(true);
        }

        protected virtual void ReleaseInstance(T instance)
        {
            instance.gameObject.SetActive(false);
        }

        protected virtual void DestroyInstance(T instance)
        {
            Destroy(instance);
        }
    }
}
