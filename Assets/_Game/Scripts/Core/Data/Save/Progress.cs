using System;
using Game.Scripts.Data;

namespace Game.Scripts.Core
{
    [Serializable]
    public class Progress
    {
        public Vector3Data Position;

        public SpawnerData SpawnerData;

        public Progress()
        {
            SpawnerData = new SpawnerData();
        }
    }
}
