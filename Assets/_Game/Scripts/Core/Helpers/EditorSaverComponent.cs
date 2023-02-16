using UnityEngine;
using Zenject;

namespace Game.Scripts.Core
{
    public class EditorSaverComponent : TickerComponent
    {
#if UNITY_EDITOR
        private ISaveLoadService _saveLoadService = default;

        private bool _isSaved = false;

        [Inject]
        void Consrtuct(ISaveLoadService saveLoadService)
        {
            _saveLoadService = saveLoadService;
        }

        public override void Enable()
        {
            base.Enable();

            Application.quitting += OnApplicationQuit;
        }

        public override void Disable()
        {
            base.Disable();

            Application.quitting -= OnApplicationQuit;
        }

        private void OnApplicationQuit()
        {
            if (_isSaved)
            {
                return;
            }

            _saveLoadService.Save();
            _isSaved = true;
        }
#endif
    }
}
