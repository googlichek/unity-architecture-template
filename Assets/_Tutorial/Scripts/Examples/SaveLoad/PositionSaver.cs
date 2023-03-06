using Game.Scripts.Core;
using Game.Scripts.Utils;
using Zenject;

namespace Tutorial.Scripts.Utils
{
    public class PositionSaver : TickerComponent, ISaveProgressWriter
    {
        private ISaveLoadService _saveLoadService;

        [Inject]
        void Construct(ISaveLoadService saveLoadService)
        {
            _saveLoadService = saveLoadService;
        }

        public override void Init()
        {
            base.Init();

            Register();
        }

        public override void Dispose()
        {
            base.Dispose();

            Delist();
        }

        public void Register()
        {
            _saveLoadService.AddWriter(this);
            _saveLoadService.AddReader(this);
        }

        public void Delist()
        {
            _saveLoadService.RemoveWriter(this);
            _saveLoadService.RemoveReader(this);
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
