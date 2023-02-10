using Game.Scripts.Core;
using UnityEngine;
using UnityEngine.UI;
using Zenject;

namespace Tutorial.Scripts.Utils
{
    public class SaveLoadButton : TickerComponent
    {
        private enum SaveLoadState
        {
            None,
            Save,
            Load
        }

        [SerializeField]
        private SaveLoadState _state = SaveLoadState.None;

        private Button _button = default;

        private ISaveLoadService _saveLoadService = default;

        [Inject]
        void Construct(ISaveLoadService saveLoadService)
        {
            _saveLoadService = saveLoadService;
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
            switch (_state)
            {
                case SaveLoadState.None:
                    break;

                case SaveLoadState.Save:
                    _saveLoadService.Save();
                    break;

                case SaveLoadState.Load:
                    _saveLoadService.Load();
                    break;
            }
        }
    }
}
