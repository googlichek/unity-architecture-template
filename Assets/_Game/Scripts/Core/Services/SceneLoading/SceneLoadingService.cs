using Cysharp.Threading.Tasks;
using UnityEngine.AddressableAssets;
using UnityEngine.SceneManagement;

namespace Game.Scripts.Core
{
    public class SceneLoadingService : TickerBehaviour, ISceneLoadingService
    {
        public async UniTask LoadScene(AssetReference sceneReference, LoadSceneMode loadMode = LoadSceneMode.Single)
        {
            await Addressables.LoadSceneAsync(sceneReference, loadMode);
        }
    }
}
