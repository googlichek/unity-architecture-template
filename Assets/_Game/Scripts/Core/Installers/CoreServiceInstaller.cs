using UnityEngine;
using Zenject;

namespace Game.Scripts.Core
{
    public class CoreServiceInstaller : MonoInstaller
    {
        [SerializeReference]
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

            Container
                .Bind<ISaveLoadService>()
                .FromComponentInHierarchy()
                .AsSingle()
                .NonLazy();
        }
    }
}
