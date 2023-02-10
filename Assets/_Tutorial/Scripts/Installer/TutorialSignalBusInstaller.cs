using Zenject;

namespace Tutorial.Scripts
{
    public class TutorialSignalBusInstaller : MonoInstaller
    {
        public override void InstallBindings()
        {
            SignalBusInstaller.Install(Container);

            Container.DeclareSignal<TutorialSignals.ChangeColorSignal>();
        }
    }
}
