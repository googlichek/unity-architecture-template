using UnityEngine;
using Zenject;

namespace Game.Scripts.Core
{
    public class EditorLoader : MonoBehaviour
    {
#if UNITY_EDITOR
        private ISaveLoadService _saveLoadService = default;

        private bool _isLoaded = false;

        [Inject]
        void Consrtuct(ISaveLoadService saveLoadService)
        {
            _saveLoadService = saveLoadService;
        }

        void Start()
        {
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
