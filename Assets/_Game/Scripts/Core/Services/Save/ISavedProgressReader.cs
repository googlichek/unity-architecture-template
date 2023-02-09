namespace Game.Scripts.Core
{
    public interface ISavedProgressReader
    {
        void Register(ISaveLoadService saveLoadService);

        void Delist(ISaveLoadService saveLoadService);

        void LoadProgress(Progress progress);
    }
}
