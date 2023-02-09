using Zenject;

namespace Game.Scripts.Core
{
    public class CoreSignalBusInstaller : MonoInstaller
    {
        public override void InstallBindings()
        {
            SignalBusInstaller.Install(Container);

            Container.DeclareSignal<Signals.ExampleSignal>();
        }
    }
}
