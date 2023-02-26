using Sirenix.OdinInspector;
using UnityEngine;

namespace Game.Scripts.Core
{
    public class SimplePoolComponent : BasePoolComponent
    {
        [FoldoutGroup("Pool Settings")]
        [SerializeReference]
        private PooledTickerBehaviour _template = default;

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

        public override void Init()
        {
            base.Init();

            InitPool(
                _template,
                _shouldUsePoolDefaults ? null : _root,
                _shouldUsePoolDefaults ? 10 : _initialSize,
                _shouldUsePoolDefaults ? 20 : _maxSize);
                
        }

        public override void Dispose()
        {
            base.Dispose();

            DisposePool();
        }
    }
}
