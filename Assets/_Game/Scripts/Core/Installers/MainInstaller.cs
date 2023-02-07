using UnityEngine;
using Zenject;

namespace Game.Scripts.Core
{
    public class MainInstaller : MonoInstaller
    {
        [SerializeField]
        private GameObject _app = default;

        public override void InstallBindings()
        {
            Container
                .Bind<IUpdateLoopService>()
                .FromComponentInNewPrefab(_app)
                .AsSingle()
                .NonLazy();

            Container
                .Bind<IInputService>()
                .FromComponentInHierarchy()
                .AsSingle()
                .NonLazy();

            Container
                .Bind<ISceneLoadingService>()
                .FromComponentInHierarchy()
                .AsSingle()
                .NonLazy();
        }
    }
}