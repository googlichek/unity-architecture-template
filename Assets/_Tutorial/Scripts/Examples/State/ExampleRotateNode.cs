using Game.Scripts.Core;
using UnityEngine;

namespace Tutorial.Scripts.Utils
{
    public class ExampleRotateNode : BaseEntityNode<ExampleStates>
    {
        [SerializeField]
        [Range(0, 10)]
        private float _nodeStayDuration = 3f;

        [SerializeField]
        [Range(0, 10)]
        private float _rotationSpeed = 5;

        private float _remainingTime = -1;

        private float _angle = 0;

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
                nextState = ExampleStates.Scale;
            }
        }

        protected override void UpdateNodeState()
        {
            Debug.Log("ROTATE STATE");

            _angle += Time.deltaTime * _rotationSpeed;
            transform.Rotate(0, _angle, 0);
        }
    }
}
