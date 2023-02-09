using DG.Tweening;
using Sirenix.OdinInspector;
using UnityEngine;
using UnityEngine.UI;

namespace Tutorial.Scripts.Utils
{
    public class FadeAndScaleAnimationComponent : MonoBehaviour
    {
        [FoldoutGroup("Tweening Settings")]
        [SerializeField]
        [Range(0, 5)]
        private float _duration = 2f;

        [FoldoutGroup("Tweening Settings")]
        [SerializeField]
        [Range(0, 5)]
        private float _scale = 3f;

        [FoldoutGroup("Tweening Settings")]
        [SerializeField]
        [Range(0, 5)]
        private float _delay = 0.5f;

        [FoldoutGroup("Tweening Settings")]
        [SerializeField]
        private Ease _easeIn = Ease.OutQuint;

        [FoldoutGroup("Tweening Settings")]
        [SerializeField]
        private Ease _easeOut = Ease.OutSine;

        private MaskableGraphic _graphic = default;

        private Sequence _sequence;
        
        void Awake()
        {
            _graphic = GetComponent<MaskableGraphic>();
            _graphic.color = new Color(_graphic.color.r, _graphic.color.g, _graphic.color.b, 0);

            CreateSequence();
        }

        public void PlayAnimation()
        {
            _sequence.Restart();
        }

        void OnDisable()
        {
            _graphic.color = new Color(_graphic.color.r, _graphic.color.g, _graphic.color.b, 0);
            _sequence.Kill(this);
        }

        private void CreateSequence()
        {
            _sequence = DOTween.Sequence();
            _sequence.SetAutoKill(false);
            _sequence.Pause();

            _sequence.Append(_graphic.DOFade(1, _duration).SetEase(_easeIn).SetDelay(_delay));
            _sequence.Join(_graphic.transform.DOScale(_scale, _duration).SetEase(_easeIn).SetDelay(_delay));
            _sequence.Append(_graphic.DOFade(0, _duration).SetEase(_easeOut).SetDelay(_delay));
            _sequence.Append(_graphic.transform.DOScale(1, 0));
        }
    }
}
