using Game.Scripts.Core;

namespace Tutorial.Scripts
{
    public class ExampleStateMachine : BaseStateMachineComponent<Priority>
    {
        public override void Init()
        {
            base.Init();

            currentState = Priority.High;
        }
    }
}
