using Zenject;

namespace Game.Scripts.Core
{
    public class EditorLoaderComponent : TickerComponent
    {
#if UNITY_EDITOR
        private ISaveLoadService _saveLoadService = default;

        private bool _isLoaded = false;

        [Inject]
        void Consrtuct(ISaveLoadService saveLoadService)
        {
            _saveLoadService = saveLoadService;
        }

        public override void Tick()
        {
            base.Tick();

            if (_isLoaded)
            {
                return;
            }

            _saveLoadService.Load();
            _isLoaded = true;
        }
#endif
    }
}
