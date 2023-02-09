namespace Game.Scripts.Core
{
    public enum Priority
    {
        None = 0,
        Low = 1,
        Normal = 2,
        High = 3
    }

    public interface ITickerComponent
    {
        int Id { get; }

        void SetId(int tickId);

        void Init();

        void Enable();

        void PhysicsTick();

        void Tick();

        void CameraTick();

        void Disable();

        void Dispose();
    }

    public interface ITicker : ITickerComponent
    {
        Priority Priority { get; }
    }
}
