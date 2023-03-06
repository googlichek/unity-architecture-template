namespace Game.Scripts.Core
{
    public interface ISaveProgressReader
    {
        void Register();

        void Delist();

        void LoadProgress(Progress progress);
    }
}
