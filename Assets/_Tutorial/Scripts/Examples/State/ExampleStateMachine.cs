using Game.Scripts.Core;

namespace Tutorial.Scripts
{
    public class ExampleStateMachine : BaseStateMachineComponent<ExampleStates>
    {
        public override void Enable()
        {
            base.Enable();

            ResetState(ExampleStates.Idle);
        }
    }
}
