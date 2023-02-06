using System.Collections.Generic;
using UnityEngine;
using Zenject;

namespace Game.Scripts.Core
{
    public abstract class TickerBehaviour : MonoBehaviour, ITicker
    {
        [SerializeReference]
        protected List<ITickerComponent> components = new List<ITickerComponent>();

        protected UpdateManager _updateManager = default;

        protected Priority priority = Priority.Normal;

        protected int id = 0;

        public Priority Priority => priority;

        public int Id => id;

        [Inject]
        protected void Construct(UpdateManager loopUpdater)
        {
            _updateManager = loopUpdater;
        }

        void Awake()
        {
            Init();
        }

        void OnEnable()
        {
            if (_updateManager.CheckIfAttached(this))
            {
                Enable();
            }
        }

        void OnDisable()
        {
            if (_updateManager.CheckIfDetached(this))
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
        /// Adds <see cref="ITickerComponent"/> to the list of updating components.
        /// </summary>
        /// <param name="component"></param>
        protected void AttachComponent(ITickerComponent component)
        {
            if (components.Contains(component))
            {
                return;
            }

            components.Add(component);
            component.Init();
        }

        /// <summary>
        /// Removes <see cref="ITickerComponent"/> from the list of updating components.
        /// </summary>
        protected void DetachComponent(ITickerComponent component)
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
