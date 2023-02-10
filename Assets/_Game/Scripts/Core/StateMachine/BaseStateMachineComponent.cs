using System;
using System.Collections.Generic;
using Game.Scripts.Utils;
using UnityEngine;

namespace Game.Scripts.Core
{
    public class BaseStateMachineComponent<TState> : TickerComponent
        where TState : struct, Enum
    {
        protected readonly Dictionary<TState, BaseEntityNode<TState>> nodesDictionary = new();

        [SerializeReference]
        protected List<BaseEntityNode<TState>> nodes = new();

        protected BaseEntityNode<TState> currentNode = default;

        protected TState currentState = default;

        public BaseEntityNode<TState> ActiveNode => currentNode;

        public TState ActiveState => currentState;
        
        public override void Init()
        {
            base.Init();

            nodesDictionary.Clear();
            for (int i = 0; i < nodes.Count; i++)
            {
                var node = nodes[i];
                nodesDictionary.Add(node.NodeState, node);
            }
        }

        public override void Tick()
        {
            UpdateState(currentNode.GetNextState());
            currentNode.Tick();
        }

        protected virtual void ResetState(TState state)
        {
            currentState = state;
            currentNode = nodesDictionary[currentState];
            currentNode.Enter(currentState);
        }

        protected void UpdateState(TState nextState)
        {
            //Debug.Log($"STATE: {nextState}");
            if (StaticMethods.EnumEquals(currentState, nextState))
            {
                return;
            }

            var existsInNodes = nodesDictionary.TryGetValue(nextState, out var nextNode);
            if (!existsInNodes)
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
