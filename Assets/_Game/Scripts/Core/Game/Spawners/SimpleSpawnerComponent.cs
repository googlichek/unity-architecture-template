using Sirenix.OdinInspector;
using UnityEngine;
using Zenject;

namespace Game.Scripts.Core
{
    public class SimpleSpawnerComponent : TickerComponent, ISpawner
    {
        [FoldoutGroup("Spawner Settings", true)]
        [Required]
        [SerializeReference]
        private TickerBehaviour _spawnedTickerTemplate = default;

        [FoldoutGroup("Spawner Settings", true)]
        [SerializeReference]
        private Transform _root = default;

        private DiContainer _container;

        public Transform Transform => transform;

        [Inject]
        void Construct(DiContainer container)
        {
            _container = container;
        }

        public override void Enable()
        {
            base.Enable();

            Spawn();
        }

        public void Spawn()
        {
            _container.InstantiatePrefabForComponent<TickerBehaviour>(_spawnedTickerTemplate, _root);
        }
    }
}
