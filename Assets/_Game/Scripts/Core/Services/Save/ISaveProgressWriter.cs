namespace Game.Scripts.Core
{
    public interface ISaveProgressWriter : ISaveProgressReader
    {
        void UpdateProgress(Progress progress);
    }
}
