using System;
using System.Collections.Generic;
using Sirenix.OdinInspector;
using UnityEngine;
using Zenject;

namespace Game.Scripts.Core
{
    public abstract class TickerBehaviour : MonoBehaviour, ITicker
    {
        public Action OnInit = default;
        public Action OnDisposed = default;

        [SerializeField]
        protected Priority priority = Priority.Normal;

        [SerializeField]
        protected bool hasComponents = true;

        [Title("Updated Components")]
        [SerializeReference]
        [ShowIf("hasComponents")]
        protected List<TickerComponent> components = new();

        protected IUpdateLoopService _updateLoopService = default;

        protected int id = 0;

        public Priority Priority => priority;

        public int Id => id;

        [Inject]
        protected void Construct(IUpdateLoopService loopUpdater)
        {
            _updateLoopService = loopUpdater;
        }

        void Awake()
        {
            Init();
        }

        void OnEnable()
        {
            if (_updateLoopService.CheckIfAttached(this))
            {
                Enable();
            }
        }

        void OnDisable()
        {
            if (_updateLoopService.CheckIfDetached(this))
            {
                Disable();
            }
        }

        void OnDestroy()
        {
            Dispose();
        }

        public void SetId(int tickId)
        {
            id = tickId;

            for (int i = 0; i < components.Count; i++)
            {
                components[i].SetId(id);
            }
        }

        public virtual void Init()
        {
            // Don't forget base;

            for (int i = 0; i < components.Count; i++)
            {
                components[i].Init();
            }

            OnInit?.Invoke();
        }

        public virtual void Enable()
        {
            // Don't forget base;

            for (int i = 0; i < components.Count; i++)
            {
                components[i].Enable();
            }
        }

        public virtual void PhysicsTick()
        {
            // Don't forget base;

            for (int i = 0; i < components.Count; i++)
            {
                components[i].PhysicsTick();
            }
        }

        public virtual void Tick()
        {
            // Don't forget base;

            for (int i = 0; i < components.Count; i++)
            {
                components[i].Tick();
            }
        }

        public virtual void CameraTick()
        {
            // Don't forget base;

            for (int i = 0; i < components.Count; i++)
            {
                components[i].CameraTick();
            }
        }

        public virtual void Disable()
        {
            // Don't forget base;

            for (int i = 0; i < components.Count; i++)
            {
                components[i].Disable();
            }
        }

        public virtual void Dispose()
        {
            // Don't forget base;

            for (int i = 0; i < components.Count; i++)
            {
                components[i].Dispose();
            }

            OnDisposed?.Invoke();
        }
    }
}
