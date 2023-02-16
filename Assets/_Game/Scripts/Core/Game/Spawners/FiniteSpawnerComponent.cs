using Sirenix.OdinInspector;
using UnityEngine;
using Zenject;

namespace Game.Scripts.Core
{
    public class FiniteSpawnerComponent : TickerComponent, ISpawner, ISavedProgressWriter
    {
        [FoldoutGroup("Spawner Settings", true)]
        [Required]
        [SerializeReference]
        private TickerBehaviour _spawnedTickerTemplate = default;

        [FoldoutGroup("Spawner Settings", true)]
        [Required]
        [SerializeReference]
        private UniqueIdComponent _uniqueIdComponent = default;

        [FoldoutGroup("Spawner Settings", true)]
        [SerializeReference]
        private Transform _root = default;

        private DiContainer _container = default;
        private ISaveLoadService _saveLoadService = default;

        private TickerBehaviour _spawnedTicker = default;

        private bool _isSpawnedTickerDestroyed = false;

        public Transform Transform => transform;

        [Inject]
        void Construct(DiContainer container, ISaveLoadService saveLoadService)
        {
            _container = container;
            _saveLoadService = saveLoadService;
        }

        public override void Init()
        {
            base.Init();

            Register(_saveLoadService);
        }

        public override void Dispose()
        {
            base.Dispose();

            Delist(_saveLoadService);

            if (_spawnedTicker != null)
            {
                _spawnedTicker.OnDisposed -= OnSpawnedTickerDestroyed;
            }
        }

        public void Register(ISaveLoadService saveLoadService)
        {
            saveLoadService.AddWriter(this);
            saveLoadService.AddReader(this);
        }

        public void Delist(ISaveLoadService saveLoadService)
        {
            saveLoadService.RemoveWriter(this);
            saveLoadService.RemoveReader(this);
        }

        public void LoadProgress(Progress progress)
        {
            if (progress.SpawnerData.ClearedSpawners.Contains(_uniqueIdComponent.UniqueId))
            {
                _isSpawnedTickerDestroyed = true;
            }
            else
            {
                Spawn();
            }
        }

        public void UpdateProgress(Progress progress)
        {
            if (_isSpawnedTickerDestroyed &&
                !progress.SpawnerData.ClearedSpawners.Contains(_uniqueIdComponent.UniqueId))
            {
                progress.SpawnerData.ClearedSpawners.Add(_uniqueIdComponent.UniqueId);
            }
        }

        public void Spawn()
        {
            _spawnedTicker = _container.InstantiatePrefabForComponent<TickerBehaviour>(_spawnedTickerTemplate, _root);
            _spawnedTicker.OnDisposed += OnSpawnedTickerDestroyed;
        }

        private void OnSpawnedTickerDestroyed()
        {
            if (_spawnedTicker != null)
            {
                _spawnedTicker.OnDisposed -= OnSpawnedTickerDestroyed;
            }

            _isSpawnedTickerDestroyed = true;
        }
    }
}
