using System.Collections.Generic;
using Game.Scripts.Utils;
using UnityEngine;

namespace Game.Scripts.Core
{
    public class SaveLoadService : MonoBehaviour, ISaveLoadService
    {
        private readonly List<ISaveProgressWriter> _progressWriters = new List<ISaveProgressWriter>();
        private readonly List<ISaveProgressReader> _progressReaders = new List<ISaveProgressReader>();

        private Progress _progress = default;

        void Awake()
        {
            InitializeProgress();

            _progressWriters.Clear();
            _progressReaders.Clear();
        }

        public void AddWriter(ISaveProgressWriter writer)
        {
            if (!_progressWriters.Contains(writer))
            {
                _progressWriters.Add(writer);
            }
        }

        public void AddReader(ISaveProgressReader reader)
        {
            if (!_progressReaders.Contains(reader))
            {
                _progressReaders.Add(reader);
            }
        }

        public void RemoveWriter(ISaveProgressWriter writer)
        {
            if (_progressWriters.Contains(writer))
            {
                _progressWriters.Remove(writer);
            }
        }

        public void RemoveReader(ISaveProgressReader reader)
        {
            if (_progressReaders.Contains(reader))
            {
                _progressReaders.Remove(reader);
            }
        }

        public void Save()
        {
            for (int i = 0; i < _progressWriters.Count; i++)
            {
                var progressWriter = _progressWriters[i];
                progressWriter.UpdateProgress(_progress);
            }

            PlayerPrefs.SetString(Constants.ProgressKey, _progress.ToJson());
        }

        public Progress Load()
        {
            for (int i = 0; i < _progressReaders.Count; i++)
            {
                var progressReader = _progressReaders[i];
                progressReader.LoadProgress(_progress);
            }

            return PlayerPrefs.GetString(Constants.ProgressKey)?.ToDeserialized<Progress>();
        }

        private void InitializeProgress()
        {
            _progress = PlayerPrefs.GetString(Constants.ProgressKey)?.ToDeserialized<Progress>();
            if (_progress == null)
            {
                _progress = new Progress();
                PlayerPrefs.SetString(Constants.ProgressKey, _progress.ToJson());
            }
        }
    }
}
