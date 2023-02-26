namespace Game.Scripts.Core
{
    public interface ISaveProgressReader
    {
        void Register(ISaveLoadService saveLoadService);

        void Delist(ISaveLoadService saveLoadService);

        void LoadProgress(Progress progress);
    }
}
