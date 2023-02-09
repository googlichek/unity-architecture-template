using Game.Scripts.Core;
using UnityEngine;

namespace Tutorial.Scripts.Utils
{
    public class Scaler : TickerComponent
    {
        [SerializeField]
        [Range(0, 10)]
        private float _scaleMultiplier = 1.5f;

        private float _scale = 0;

        public override void Tick()
        {
            _scale = Mathf.Clamp(Mathf.Sin(Time.time) * _scaleMultiplier, 0.25f, 1.5f);
            var newScale = new Vector3(_scale, _scale, _scale);
            transform.localScale = newScale;
        }
    }
}
