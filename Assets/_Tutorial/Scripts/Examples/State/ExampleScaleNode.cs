using Game.Scripts.Core;
using UnityEngine;

namespace Tutorial.Scripts.Utils
{
    public class ExampleScaleNode : BaseEntityNode<ExampleStates>
    {
        [SerializeField]
        [Range(0, 10)]
        private float _nodeStayDuration = 3f;

        [SerializeField]
        [Range(0, 10)]
        private float _scaleMultiplier = 1.5f;

        private float _remainingTime = -1;

        private float _scale = 0;

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
                nextState = ExampleStates.Idle;
            }
        }

        protected override void UpdateNodeState()
        {
            Debug.Log("Scale STATE");

            _scale = Mathf.Clamp(Mathf.Sin(Time.time) * _scaleMultiplier, 0.25f, 1.5f);
            var newScale = new Vector3(_scale, _scale, _scale);
            transform.localScale = newScale;
        }
    }
}
