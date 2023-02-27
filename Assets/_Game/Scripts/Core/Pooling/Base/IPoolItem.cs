using UnityEngine;

namespace Game.Scripts.Core
{
    public interface IPoolItem<T>
        where T : MonoBehaviour, IPoolItem<T>
    {
        void Setup(BasePoolComponent<T> owningPool);

        void ReleaseSelf();
    }
}
