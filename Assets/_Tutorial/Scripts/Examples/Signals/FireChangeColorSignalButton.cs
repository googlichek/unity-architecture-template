using Game.Scripts.Core;
using UnityEngine;
using UnityEngine.UI;
using Zenject;

namespace Tutorial.Scripts.Utils
{
    public class FireChangeColorSignalButton : TickerComponent
    {
        private SignalBus _signalBus;

        private Button _button = default;

        [Inject]
        void Construct(SignalBus signalBus)
        {
            _signalBus = signalBus;
        }

        public override void Init()
        {
            base.Init();

            _button = GetComponent<Button>();

            _button.onClick.AddListener(OnButtonClick);
        }

        public override void Dispose()
        {
            base.Dispose();

            _button.onClick.RemoveListener(OnButtonClick);
        }

        private void OnButtonClick()
        {
            var color = Random.ColorHSV();
            var signal = new TutorialSignals.ChangeColorSignal(color);

            _signalBus.TryFire(signal);
        }
    }
}
