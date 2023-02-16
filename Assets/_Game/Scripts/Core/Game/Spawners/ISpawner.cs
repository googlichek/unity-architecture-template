using UnityEngine;

namespace Game.Scripts.Core
{
    public interface ISpawner
    {
        Transform Transform { get; }

        void Spawn();
    }
}