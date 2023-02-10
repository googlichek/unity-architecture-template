using Game.Scripts.Core;
using UnityEngine;
using Zenject;

namespace Tutorial.Scripts.Utils
{
    public class ChangeColor : TickerComponent
    {
        private MaterialPropertyBlock _propertyBlock = default;

        private Renderer _renderer = default;

        private SignalBus _signalBus;

        [Inject]
        void Construct(SignalBus signalBus)
        {
            _signalBus = signalBus;
        }

        public override void Init()
        {
            base.Init();

            _renderer = GetComponent<Renderer>();

            _propertyBlock = new MaterialPropertyBlock();
            _renderer.GetPropertyBlock(_propertyBlock);
        }

        public override void Enable()
        {
            base.Enable();

            _signalBus.Subscribe<TutorialSignals.ChangeColorSignal>(x => OnSignal(x.Color));
        }
        public override void Disable()
        {
            base.Disable();

            _signalBus.TryUnsubscribe<TutorialSignals.ChangeColorSignal>(x => OnSignal(x.Color));
        }

        private void OnSignal(Color color)
        {
            _propertyBlock.SetColor("_Color", color);
            _renderer.SetPropertyBlock(_propertyBlock);
        }
    }
}
