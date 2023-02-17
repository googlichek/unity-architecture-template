using Zenject;

namespace Game.Scripts.Core
{
    public class EditorSaver : TickerComponent
    {
#if UNITY_EDITOR
        private ISaveLoadService _saveLoadService = default;

        private bool _isSaved = false;

        [Inject]
        void Consrtuct(ISaveLoadService saveLoadService)
        {
            _saveLoadService = saveLoadService;
        }

        void OnApplicationQuit()
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
