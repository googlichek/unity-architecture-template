using UnityEngine;
using Zenject;

namespace Game.Scripts.Core
{
    public class UpdateManagerInstaller : MonoInstaller
    {
        [SerializeField]
        private GameObject _updateManager = default;

        public override void InstallBindings()
        {
            Container
                .Bind<UpdateManager>()
                .FromComponentInNewPrefab(_updateManager)
                .AsSingle()
                .NonLazy();
        }
    }
}
