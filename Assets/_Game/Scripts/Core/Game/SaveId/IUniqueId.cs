using UnityEngine;

namespace Game.Scripts.Core
{
    public interface IUniqueId
    {
        string UniqueId { get; }

        public bool IsUnique { get; }

        void GenerateUniqueId();
    }
}
