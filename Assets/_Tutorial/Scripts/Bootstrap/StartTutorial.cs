using Game.Scripts.Core;
using UnityEngine;
using UnityEngine.AddressableAssets;
using Zenject;

namespace Tutorial.Scripts.Utils
{
    public class StartTutorial : TickerBehaviour
    {
        [SerializeField]
        private AssetReference _nextScene = default;

        private ISceneLoadingService _sceneLoadingService;

        [Inject]
        void Construct(ISceneLoadingService sceneLoadingService)
        {
            _sceneLoadingService = sceneLoadingService;
        }

        public override async void Init()
        {
            await _sceneLoadingService.LoadScene(_nextScene);
        }
    }
}
