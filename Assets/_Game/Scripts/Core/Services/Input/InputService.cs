using Rewired;
using UnityEngine;

namespace Game.Scripts.Core
{
    public class InputService : TickerBehaviour, IInputService
    {
        [SerializeField]
        private GameObject _rewiredInputManagerTemplate = default;

        private Player _player;

        private int _playerId = 0;

        private float _horizontal = 0;
        private float _vertical = 0;

        private float _lookX = 0;
        private float _lookY = 0;

        private bool _isJumpPressed = false;
        private bool _isJumpReleased = false;
        private bool _isJumpHeld = false;

        public float Horizontal => _horizontal;
        public float Vertical => _vertical;

        public float LookX => _lookX;
        public float LookY => _lookY;

        public bool IsJumpPressed => _isJumpPressed;
        public bool IsJumpReleased => _isJumpReleased;
        public bool IsJumpHeld => _isJumpHeld;

        public override void Init()
        {
            priority = Core.Priority.High;

            Instantiate(_rewiredInputManagerTemplate, transform.parent);

            _player = ReInput.players.GetPlayer(_playerId);
        }

        public override void Tick()
        {
            HandleInput();
        }

        private void HandleInput()
        {
            _horizontal = _player.GetAxis(InputActions.Horizontal);
            _vertical = _player.GetAxis(InputActions.Vertical);

            _lookX = _player.GetAxis(InputActions.LookX);
            _lookY = _player.GetAxis(InputActions.LookY);

            _isJumpPressed = _player.GetButtonDown(InputActions.Jump);
            _isJumpReleased = _player.GetButtonUp(InputActions.Jump);
            _isJumpHeld = _player.GetButton(InputActions.Jump);
        }
    }
}
