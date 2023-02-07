using System.Collections.Generic;
using UnityEngine;
using Zenject;

namespace Game.Scripts.Core
{
    public abstract class TickerBehaviour : MonoBehaviour, ITicker
    {
        [SerializeField]
        protected Priority priority = Priority.Normal;

        [SerializeReference]
        protected List<TickerComponent> components = new List<TickerComponent>();

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
            // Override this method with base;

            for (int i = 0; i < components.Count; i++)
            {
                components[i].Init();
            }
        }

        public virtual void Enable()
        {
            // Override this method with base;

            for (int i = 0; i < components.Count; i++)
            {
                components[i].Enable();
            }
        }

        public virtual void PhysicsTick()
        {
            // Override this method with base;

            for (int i = 0; i < components.Count; i++)
            {
                components[i].PhysicsTick();
            }
        }

        public virtual void Tick()
        {
            // Override this method with base;

            for (int i = 0; i < components.Count; i++)
            {
                components[i].Tick();
            }
        }

        public virtual void CameraTick()
        {
            // Override this method with base;

            for (int i = 0; i < components.Count; i++)
            {
                components[i].CameraTick();
            }
        }

        public virtual void Disable()
        {
            // Override this method with base;

            for (int i = 0; i < components.Count; i++)
            {
                components[i].Disable();
            }
        }

        public virtual void Dispose()
        {
            // Override this method with base;

            for (int i = 0; i < components.Count; i++)
            {
                components[i].Dispose();
            }

            components.Clear();
        }

        /// <summary>
        /// Adds <see cref="TickerComponent"/> to the list of updating components.
        /// </summary>
        /// <param name="component"></param>
        protected void AttachComponent(TickerComponent component)
        {
            if (components.Contains(component))
            {
                return;
            }

            components.Add(component);
            component.Init();
        }

        /// <summary>
        /// Removes <see cref="TickerComponent"/> from the list of updating components.
        /// </summary>
        protected void DetachComponent(TickerComponent component)
        {
            if (!components.Contains(component))
            {
                return;
            }

            component.Dispose();
            components.Remove(component);
        }
    }
}
