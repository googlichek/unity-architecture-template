using Cysharp.Threading.Tasks;
using UnityEngine.AddressableAssets;

namespace Game.Scripts.Core
{
    public interface IAssetProvider
    {
        UniTask<T> Load<T>(AssetReference assetReference) where T : class;
        UniTask<T> Load<T>(string path) where T : class;

        void Cleanup();
    }
}
