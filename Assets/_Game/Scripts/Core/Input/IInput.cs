namespace Game.Scripts.Core
{
    public interface IInput
    {
	    public float Horizontal { get; }
        public float Vertical { get; }

        public float LookX { get; }
        public float LookY { get; }

        public bool IsJumpPressed { get; }
        public bool IsJumpReleased { get; }
        public bool IsJumpHeld { get; }
    }
}
