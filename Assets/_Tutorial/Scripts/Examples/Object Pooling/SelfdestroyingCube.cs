using Game.Scripts.Core;
using UnityEngine;

namespace Tutorial.Scripts.Utils
{
    public class SelfdestroyingCube : PooledTickerBehaviour
    {
        [SerializeField]
        [Range(0, 10)]
        private float _lifeTime = 5f;

        private float _remainingLifeTime = 0;

        public override void Enable()
        {
            base.Enable();

            _remainingLifeTime = _lifeTime;
        }

        public override void Tick()
        {
            base.Tick();

            _remainingLifeTime -= Time.deltaTime;

            if (_remainingLifeTime < 0)
            {
                pool.Release(this);
            }
        }
    }
}
