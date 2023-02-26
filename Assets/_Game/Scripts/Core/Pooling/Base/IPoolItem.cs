using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Game.Scripts.Core
{
    public interface IPoolItem
    {
        void Setup(BasePoolComponent owningPool);

        void ReleaseSelf();
    }
}
