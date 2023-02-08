using UnityEngine;

namespace Game.Scripts.Core
{
    public abstract class TickerComponent : MonoBehaviour, ITickerComponent
    {
        protected int id;

        public int Id => id;

        public void SetId(int tickId)
        {
            id = tickId;
        }

        public virtual void Init()
        {
            // You can override this method without base;
        }

        public virtual void Enable()
        {
            // You can override this method without base;
        }

        public virtual void PhysicsTick()
        {
            // You can override this method without base;
        }

        public virtual void Tick()
        {
            // You can override this method without base;
        }

        public virtual void CameraTick()
        {
            // You can override this method without base;
        }

        public virtual void Disable()
        {
            // You can override this method without base;
        }

        public virtual void Dispose()
        {
            // You can override this method without base;
        }
    }
}
