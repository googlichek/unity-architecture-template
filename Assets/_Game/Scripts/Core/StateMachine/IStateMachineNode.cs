﻿using System;

namespace Game.Scripts.Core
{
    public interface IStateMachineNode<T> where T : struct, Enum
    {
        void Enter(T from);

        void Tick();

        void Exit(T to);

        T GetNextState();
    }
}
