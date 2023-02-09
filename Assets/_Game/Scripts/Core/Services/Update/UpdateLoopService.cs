using UnityEngine;

namespace Game.Scripts.Core
{
    public class UpdateLoopService : MonoBehaviour, IUpdateLoopService
    {
        private readonly ITicker[] _highPriorityTickers =
            new ITicker[Constants.MaxUpdatedObjectsWithHighPriority];
        private readonly ITicker[] _normalPriorityTickers =
            new ITicker[Constants.MaxUpdatedObjectsWithNormalPriority];
        private readonly ITicker[] _lowPriorityTickers =
            new ITicker[Constants.MaxUpdatedObjectsWithLowPriority];

        private int _instanceCounter;
        private int _tick;

        public int Tick => _tick;

        void Awake()
        {
            Application.targetFrameRate = Constants.TargetFrameRate;
        }

        void FixedUpdate()
        {
            for (int i = 0; i < _highPriorityTickers.Length; i++)
            {
                _highPriorityTickers[i]?.PhysicsTick();
            }

            for (int i = 0; i < _normalPriorityTickers.Length; i++)
            {
                _normalPriorityTickers[i]?.PhysicsTick();
            }

            for (int i = 0; i < _lowPriorityTickers.Length; i++)
            {
                _lowPriorityTickers[i]?.PhysicsTick();
            }
        }

        void Update()
        {
            _tick++;

            for (int i = 0; i < _highPriorityTickers.Length; i++)
            {
                _highPriorityTickers[i]?.Tick();
            }

            for (int i = 0; i < _normalPriorityTickers.Length; i++)
            {
                _normalPriorityTickers[i]?.Tick();
            }

            for (int i = 0; i < _lowPriorityTickers.Length; i++)
            {
                _lowPriorityTickers[i]?.Tick();
            }
        }

        void LateUpdate()
        {
            for (int i = 0; i < _highPriorityTickers.Length; i++)
            {
                _highPriorityTickers[i]?.CameraTick();
            }

            for (int i = 0; i < _normalPriorityTickers.Length; i++)
            {
                _normalPriorityTickers[i]?.CameraTick();
            }

            for (int i = 0; i < _lowPriorityTickers.Length; i++)
            {
                _lowPriorityTickers[i]?.CameraTick();
            }
        }

        public bool CheckIfAttached(ITicker ticker)
        {
            if (ticker.Id == 0)
            {
                _instanceCounter++;
                ticker.SetId(_instanceCounter);
            }

            switch (ticker.Priority)
            {
                case Priority.High:
                {
                    for (int index = 0; index < _highPriorityTickers.Length; index++)
                    {
                        if (_highPriorityTickers[index] == null)
                        {
                            _highPriorityTickers[index] = ticker;
                            return true;
                        }
                    }

                    break;
                }

                case Priority.Normal:
                {
                    for (int index = 0; index < _normalPriorityTickers.Length; index++)
                    {
                        if (_normalPriorityTickers[index] == null)
                        {
                            _normalPriorityTickers[index] = ticker;
                            return true;
                        }
                    }

                    break;
                }

                case Priority.Low:
                {
                    for (int index = 0; index < _lowPriorityTickers.Length; index++)
                    {
                        if (_lowPriorityTickers[index] == null)
                        {
                            _lowPriorityTickers[index] = ticker;
                            return true;
                        }
                    }

                    break;
                }
            }

            return false;
        }

        public bool CheckIfDetached(ITicker ticker)
        {
            switch (ticker.Priority)
            {
                case Priority.High:
                {
                    for (int index = 0; index < _highPriorityTickers.Length; index++)
                    {
                        if (_highPriorityTickers[index] == ticker)
                        {
                            _highPriorityTickers[index] = null;
                            return true;
                        }
                    }

                    break;
                }

                case Priority.Normal:
                {
                    for (int index = 0; index < _normalPriorityTickers.Length; index++)
                    {
                        if (_normalPriorityTickers[index] == ticker)
                        {
                            _normalPriorityTickers[index] = null;
                            return true;
                        }
                    }

                    break;
                }

                case Priority.Low:
                {
                    for (int index = 0; index < _lowPriorityTickers.Length; index++)
                    {
                        if (_lowPriorityTickers[index] == ticker)
                        {
                            _lowPriorityTickers[index] = null;
                            return true;
                        }
                    }

                    break;
                }
            }

            return false;
        }
    }
}
