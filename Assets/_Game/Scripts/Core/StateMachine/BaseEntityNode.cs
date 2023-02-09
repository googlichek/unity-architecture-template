using System;
using Game.Scripts.Utils;
using UnityEngine;

namespace Game.Scripts.Core
{
    public abstract class BaseEntityNode<TState> : MonoBehaviour, IStateMachineNode<TState>
        where TState : struct, Enum
    {
        [SerializeField]
        protected TState nodeState;

        protected TState enterState;
        protected TState nextState;
        protected TState exitState;

        public TState NodeState => nodeState;

        public virtual void Enter(TState from)
        {
            enterState = from;
            nextState = NodeState;
        }

        public virtual void Tick()
        {
            if (StaticMethods.EnumEquals(nextState, NodeState))
            {
                UpdateNodeState();
            }

            UpdateNextState();
        }

        public virtual void Exit(TState to)
        {
            exitState = to;
        }

        public virtual TState GetNextState()
        {
            return nextState;
        }

        protected abstract void UpdateNextState();

        protected abstract void UpdateNodeState();
    }
}
