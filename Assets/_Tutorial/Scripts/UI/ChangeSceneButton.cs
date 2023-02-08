using Game.Scripts.Core;
using UnityEngine;
using UnityEngine.AddressableAssets;
using UnityEngine.UI;
using Zenject;

namespace Tutorial.Scripts.Utils
{
    public class ChangeSceneButton : TickerComponent
    {
        [SerializeField]
        private AssetReference _nextScene = default;

        private ISceneLoadingService _sceneLoadingService;

        private Button _button = default;

        [Inject]
        void Construct(ISceneLoadingService sceneLoadingService)
        {
            _sceneLoadingService = sceneLoadingService;
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

        private async void OnButtonClick()
        {
            if (string.IsNullOrEmpty(_nextScene.AssetGUID))
            {
                Debug.LogWarningFormat("No next scene referenced in the component", this);
                return;
            }

            await _sceneLoadingService.LoadScene(_nextScene);
        }
    }
}
