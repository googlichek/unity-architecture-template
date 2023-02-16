using System;
using UnityEngine;

namespace Game.Scripts.Core
{
    public class UniqueIdComponent : TickerComponent, IUniqueId
    {
        [SerializeField]
        private string _uniqueId = string.Empty;

        public string UniqueId => _uniqueId;

        public bool IsUnique => _uniqueId != string.Empty;

        public void GenerateUniqueId()
        {
            _uniqueId = $"{gameObject.scene.name}_{Guid.NewGuid().ToString()}";
        }
    }
}
