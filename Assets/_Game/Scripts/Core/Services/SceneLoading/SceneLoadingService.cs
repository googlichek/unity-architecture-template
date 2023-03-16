using Cysharp.Threading.Tasks;
using UnityEngine;
using UnityEngine.AddressableAssets;
using UnityEngine.SceneManagement;

namespace Game.Scripts.Core
{
    public class SceneLoadingService : MonoBehaviour, ISceneLoadingService
    {
        public async UniTask LoadScene(AssetReference sceneReference, LoadSceneMode loadMode = LoadSceneMode.Single)
        {
            if (string.IsNullOrEmpty(sceneReference.AssetGUID))
            {
                Debug.LogWarningFormat("No valid scene to load", this);
                return;
            }

            await Addressables.LoadSceneAsync(sceneReference, loadMode);
        }
    }
}
