using Game.Scripts.Core;
using UnityEngine;

namespace Tutorial.Scripts.Utils
{
    public class ExampleIdleNode : BaseEntityNode<ExampleStates>
    {

        [SerializeField]
        [Range(0, 10)]
        private float _nodeStayDuration = 3f;

        private float _remainingTime = -1;

        public override void Enter(ExampleStates from)
        {
            base.Enter(from);

            _remainingTime = _nodeStayDuration;
        }

        protected override void UpdateNextState()
        {
            _remainingTime -= Time.deltaTime;

            if (_remainingTime < 0)
            {
                nextState = ExampleStates.Rotate;
            }
        }

        protected override void UpdateNodeState()
        {
            Debug.Log("IDLE STATE");
        }
    }
}
