using UnityEngine;

namespace Game.Scripts.Core
{
    public interface IPoolItem<T>
    {
        void Setup(IPool<T> owningPool);

        void ReleaseSelf();
    }
}
