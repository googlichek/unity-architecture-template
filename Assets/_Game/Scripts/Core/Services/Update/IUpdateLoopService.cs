namespace Game.Scripts.Core
{
    public interface IUpdateLoopService
    {
        int Tick { get; }

        public bool CheckIfAttached(ITicker ticker);

        public bool CheckIfDetached(ITicker ticker);
    }
}
