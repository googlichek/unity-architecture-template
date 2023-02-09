namespace Game.Scripts.Core
{
    public interface ISaveLoadService
    {
        void AddWriter(ISavedProgressWriter writer);

        void AddReader(ISavedProgressReader reader);

        void RemoveWriter(ISavedProgressWriter writer);

        void RemoveReader(ISavedProgressReader reader);

        void Save();

        Progress Load();
    }
}
