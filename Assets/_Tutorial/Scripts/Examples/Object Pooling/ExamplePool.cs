using Game.Scripts.Core;
using Sirenix.OdinInspector;
using UnityEngine;

namespace Tutorial.Scripts.Utils
{
    public class ExamplePool : BasePool<PooledTickerBehaviour>
    {
        [FoldoutGroup("Pool Settings")]
        [SerializeReference]
        private PooledTickerBehaviour _objectTemplate = default;

        [FoldoutGroup("Pool Settings")]
        [SerializeField]
        private bool _shouldUsePoolDefaults = false;

        [FoldoutGroup("Pool Settings")]
        [ShowIf("@!_shouldUsePoolDefaults")]
        [SerializeReference]
        private Transform _root = default;

        [FoldoutGroup("Pool Settings")]
        [ShowIf("@!_shouldUsePoolDefaults")]
        [SerializeField]
        [Range(0, 1000)]
        private int _initialSize = 10;

        [FoldoutGroup("Pool Settings")]
        [ShowIf("@!_shouldUsePoolDefaults")]
        [SerializeField]
        [Range(0, 1000)]
        private int _maxSize = 20;

        [SerializeField]
        [Range(0, 10)]
        private float _spawnDelay = 2f;

        private float _timeBeforeNextSpawn = -1;

        public override void Init()
        {
            base.Init();

            InitPool(
                _objectTemplate,
                _shouldUsePoolDefaults ? null : _root,
                _shouldUsePoolDefaults ? 10 : _initialSize,
                _shouldUsePoolDefaults ? 20 : _maxSize);
        }

        public override void Enable()
        {
            base.Enable();

            _timeBeforeNextSpawn = _spawnDelay;
        }

        public override void Tick()
        {
            base.Tick();

            if (_timeBeforeNextSpawn < 0)
            {
                Spawn();
                _timeBeforeNextSpawn = _spawnDelay;
            }

            _timeBeforeNextSpawn -= Time.deltaTime;
        }

        public override void Dispose()
        {
            base.Dispose();

            DisposePool();
        }

        private void Spawn()
        {
            var spawnPosition = transform.position + (Random.insideUnitSphere * 5);

            var spawnedObject = Get();
            spawnedObject.transform.localPosition = spawnPosition;
        }
    }
}
