namespace Game.Scripts.Core
{
    public interface ISavedProgressReader
    {
        void RegisterWith(ISaveLoadService saveLoadService);

        void DeregisterWith(ISaveLoadService saveLoadService);

        void LoadProgress(Progress progress);
    }
}
