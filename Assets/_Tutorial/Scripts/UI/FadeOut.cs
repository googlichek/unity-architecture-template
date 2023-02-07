using DG.Tweening;
using Game.Scripts.Core;
using UnityEngine;
using UnityEngine.UI;

namespace Tutorial.Scripts.Utils
{
    public class FadeOut : TickerComponent
    {
        [SerializeField]
        [Range(0, 5)]
        private float _duration = 0.5f;

        [SerializeField]
        [Range(0, 5)]
        private float _delay = 0.5f;

        [SerializeField]
        private Ease _ease = Ease.OutQuint;

        private MaskableGraphic _graphic = default;
        
        public override void Init()
        {
            base.Init();

            _graphic = GetComponent<MaskableGraphic>();
            _graphic.color = new Color(_graphic.color.r, _graphic.color.g, _graphic.color.b, 0);
        }

        public override void Enable()
        {
            base.Enable();

            _graphic.DOFade(1, _duration).SetEase(_ease).SetDelay(_delay);
        }

        public override void Disable()
        {
            base.Disable();

            _graphic.color = new Color(_graphic.color.r, _graphic.color.g, _graphic.color.b, 0);
            DOTween.Kill(this);
        }
    }
}
