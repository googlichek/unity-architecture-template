using Cysharp.Threading.Tasks;
using UnityEngine.AddressableAssets;
using UnityEngine.SceneManagement;

namespace Game.Scripts.Core
{
    public interface ISceneLoadingService
    {
        UniTask LoadScene(AssetReference sceneReference, LoadSceneMode loadMode = LoadSceneMode.Single);
    }
}
