using Game.Scripts.Core;
using UnityEngine;
using UnityEngine.UI;

namespace Tutorial.Scripts.Utils
{
    public class PositionRandomizerButton : TickerComponent
    {
        [SerializeReference]
        private Transform _root = default;

        [SerializeReference]
        private GameObject _cube = default;

        private Button _button = default;

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
            RandomizePosition();
        }

        public void RandomizePosition()
        {
            var position = _root.position + (Random.insideUnitSphere * 2);
            _cube.transform.position = position;
        }
    }
}
