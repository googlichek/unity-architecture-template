using Game.Scripts.Core;
using UnityEngine;

namespace Tutorial.Scripts.Utils
{
    public class Rotator : TickerComponent
    {
        [SerializeField]
        [Range(0, 10)]
        private float _rotationSpeed = 5;

        private float _angle = 0;

        public override void Tick()
        {
            _angle += Time.deltaTime * _rotationSpeed;
            transform.Rotate(0, _angle, 0);
        }
    }
}
