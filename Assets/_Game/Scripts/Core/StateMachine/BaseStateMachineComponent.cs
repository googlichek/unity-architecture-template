using System;
using System.Collections.Generic;
using Game.Scripts.Utils;
using UnityEngine;

namespace Game.Scripts.Core
{
    public class BaseStateMachineComponent<TState> : TickerComponent
        where TState : struct, Enum
    {
        [SerializeReference]
        protected List<BaseEntityNode<TState>> nodes = new();

        protected BaseEntityNode<TState> currentNode = default;

        protected TState currentState = default;

        public BaseEntityNode<TState> ActiveNode => currentNode;

        public TState ActiveState => currentState;

        public override void Tick()
        {
            UpdateState(currentNode.GetNextState());
            currentNode.Tick();
        }

        protected virtual void ResetState(TState state)
        {
            currentState = state;
            for (int i = 0; i < nodes.Count; i++)
            {
                var node = nodes[i];
                if (!StaticMethods.EnumEquals(node.NodeState, currentState))
                {
                    continue;
                }

                currentNode = node;
                currentNode.Enter(currentState);
                break;
            }
        }

        protected void UpdateState(TState nextState)
        {
            //Debug.Log($"STATE: {nextState}");
            if (StaticMethods.EnumEquals(currentState, nextState))
            {
                return;
            }

            BaseEntityNode<TState> nextNode = null;
            for (int i = 0; i < nodes.Count; i++)
            {
                var node = nodes[i];
                if (!StaticMethods.EnumEquals(node.NodeState, nextState))
                {
                    continue;
                }

                nextNode = node;
                break;
            }

            if (nextNode == null)
            {
                Debug.LogError($"Trying to transition to nonexistent state node: {nextState}");
                return;
            }

            currentNode.Exit(nextState);
            currentNode = nextNode;

            currentNode.Enter(currentState);
            currentState = nextState;
        }
    }
}
