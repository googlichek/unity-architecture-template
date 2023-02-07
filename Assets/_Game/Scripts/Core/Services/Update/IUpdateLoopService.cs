namespace Game.Scripts.Core
{
    public interface IUpdateLoopService
    {
        public bool CheckIfAttached(ITicker ticker);

        public bool CheckIfDetached(ITicker ticker);
    }
}
