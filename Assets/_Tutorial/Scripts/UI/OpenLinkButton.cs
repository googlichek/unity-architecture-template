using Game.Scripts.Core;
using UnityEngine;
using UnityEngine.UI;

namespace Tutorial.Scripts.Utils
{
    public class OpenLinkButton : TickerComponent
    {
#if UNITY_EDITOR
        [SerializeField]
        private string _url = default;

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
            Application.OpenURL(_url);
        }
    }
#endif
}
