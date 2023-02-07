using Game.Scripts.Core;
using UnityEditor;
using UnityEngine;
using UnityEngine.UI;

namespace Tutorial.Scripts.Utils
{
    public class ShowAssetButton : TickerComponent
    {
#if UNITY_EDITOR
        [SerializeField]
        private string _pathToAsset = default;

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
            Selection.activeObject = AssetDatabase.LoadMainAssetAtPath(_pathToAsset);
        }
    }
#endif
}
