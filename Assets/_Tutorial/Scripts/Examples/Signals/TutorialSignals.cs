using UnityEngine;

namespace Tutorial.Scripts
{
    public static class TutorialSignals
    {
        public class ChangeColorSignal
        {
            private Color _color;

            public Color Color => _color;

            public ChangeColorSignal(Color color)
            {
                _color = color;
            }
        }
    }
}
