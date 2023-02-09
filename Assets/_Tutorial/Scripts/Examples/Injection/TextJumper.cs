using Game.Scripts.Core;
using UnityEngine;
using Zenject;

namespace Tutorial.Scripts.Utils
{
    public class TextJumper : MonoBehaviour
    {
        private FadeAndScaleAnimationComponent _animationComponent = default;

        private IInputService _inputService = default;

        [Inject]
        void Construct(IInputService inputService)
        {
            _inputService = inputService;
        }

        void Awake()
        {
            _animationComponent = GetComponent<FadeAndScaleAnimationComponent>();
        }

        void Update()
        {
            if (_inputService.IsJumpPressed)
            {
                _animationComponent.PlayAnimation();
            }
        }
    }
}
