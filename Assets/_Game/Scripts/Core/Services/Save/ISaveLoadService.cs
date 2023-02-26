namespace Game.Scripts.Core
{
    public interface ISaveLoadService
    {
        void AddWriter(ISaveProgressWriter writer);

        void AddReader(ISaveProgressReader reader);

        void RemoveWriter(ISaveProgressWriter writer);

        void RemoveReader(ISaveProgressReader reader);

        void Save();

        Progress Load();
    }
}
