namespace Game.Scripts.Core
{
    public interface ISavedProgressWriter : ISavedProgressReader
    {
        void UpdateProgress(Progress progress);
    }
}
