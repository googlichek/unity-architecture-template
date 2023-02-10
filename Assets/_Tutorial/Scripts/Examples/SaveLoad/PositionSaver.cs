using Game.Scripts.Core;
using Game.Scripts.Utils;
using Zenject;

namespace Tutorial.Scripts.Utils
{
    public class PositionSaver : TickerComponent, ISavedProgressWriter
    {
        private ISaveLoadService _saveLoadService;

        [Inject]
        void Construct(ISaveLoadService saveLoadService)
        {
            _saveLoadService = saveLoadService;
        }

        public override void Enable()
        {
            base.Enable();

            Register(_saveLoadService);
        }

        public override void Disable()
        {
            base.Disable();

            Delist(_saveLoadService);
        }

        public void Register(ISaveLoadService saveLoadService)
        {
            saveLoadService.AddWriter(this);
            saveLoadService.AddReader(this);
        }

        public void Delist(ISaveLoadService saveLoadService)
        {
            saveLoadService.RemoveWriter(this);
            saveLoadService.RemoveReader(this);
        }

        public void LoadProgress(Progress progress)
        {
            transform.position = progress.Position.AsUnityVector();
        }

        public void UpdateProgress(Progress progress)
        {
            progress.Position = transform.position.AsVectorData();
        }
    }
}
