using System.Collections.Generic;
using UnityEngine;

namespace Game.Scripts.Core
{
    public class UpdateLoopService : MonoBehaviour, IUpdateLoopService
    {
        private readonly List<ITicker> _lowPriorityTickers =
            new List<ITicker>(Constants.MaxUpdatedObjectsWithLowPriority);
        private readonly List<ITicker> _normalPriorityTickers =
            new List<ITicker>(Constants.MaxUpdatedObjectsWithNormalPriority);
        private readonly List<ITicker> _highPriorityTickers =
            new List<ITicker>(Constants.MaxUpdatedObjectsWithHighPriority);

        private int _instanceCounter;
        private int _tick;

        public int Tick => _tick;

        void Awake()
        {
            Application.targetFrameRate = Constants.TargetFrameRate;
        }

        void FixedUpdate()
        {
            for (int i = 0; i < _highPriorityTickers.Count; i++)
            {
                _highPriorityTickers[i]?.PhysicsTick();
            }

            for (int i = 0; i < _normalPriorityTickers.Count; i++)
            {
                _normalPriorityTickers[i]?.PhysicsTick();
            }

            for (int i = 0; i < _lowPriorityTickers.Count; i++)
            {
                _lowPriorityTickers[i]?.PhysicsTick();
            }
        }

        void Update()
        {
            _tick++;

            for (int i = 0; i < _highPriorityTickers.Count; i++)
            {
                _highPriorityTickers[i]?.Tick();
            }

            for (int i = 0; i < _normalPriorityTickers.Count; i++)
            {
                _normalPriorityTickers[i]?.Tick();
            }

            for (int i = 0; i < _lowPriorityTickers.Count; i++)
            {
                _lowPriorityTickers[i]?.Tick();
            }
        }

        void LateUpdate()
        {
            for (int i = 0; i < _highPriorityTickers.Count; i++)
            {
                _highPriorityTickers[i]?.CameraTick();
            }

            for (int i = 0; i < _normalPriorityTickers.Count; i++)
            {
                _normalPriorityTickers[i]?.CameraTick();
            }

            for (int i = 0; i < _lowPriorityTickers.Count; i++)
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
                    var containsInTickers = _highPriorityTickers.Contains(ticker);
                    if (containsInTickers)
                    {
                        return false;
                    }

                    for (int index = 0; index < _highPriorityTickers.Count; index++)
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
                    var containsInTickers = _normalPriorityTickers.Contains(ticker);
                    if (containsInTickers)
                    {
                        return false;
                    }

                    for (int index = 0; index < _normalPriorityTickers.Count; index++)
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
                    var containsInTickers = _lowPriorityTickers.Contains(ticker);
                    if (containsInTickers)
                    {
                        return false;
                    }

                    for (int index = 0; index < _lowPriorityTickers.Count; index++)
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

            return true;
        }

        public bool CheckIfDetached(ITicker ticker)
        {
            switch (ticker.Priority)
            {
                case Priority.High:
                {
                    var containsInTickers = _highPriorityTickers.Contains(ticker);
                    if (containsInTickers)
                    {
                        return false;
                    }

                    for (int index = 0; index < _highPriorityTickers.Count; index++)
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
                    var containsInTickers = _normalPriorityTickers.Contains(ticker);
                    if (containsInTickers)
                    {
                        return false;
                    }

                    for (int index = 0; index < _normalPriorityTickers.Count; index++)
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
                    var containsInTickers = _lowPriorityTickers.Contains(ticker);
                    if (containsInTickers)
                    {
                        return false;
                    }

                    for (int index = 0; index < _lowPriorityTickers.Count; index++)
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

            return true;
        }
    }
}
