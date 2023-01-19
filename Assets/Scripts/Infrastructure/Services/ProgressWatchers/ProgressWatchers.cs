using System.Collections.Generic;
using Infrastructure.Services.PersistentProgress;
using UnityEngine;

namespace Infrastructure.Services.ProgressWatchers
{
    public class ProgressWatchers : IProgressWatchers
    {
        private readonly List<ISavedProgressReader> _readers = new();
        private readonly List<ISavedProgressWriter> _writers = new();

        private readonly IPersistentProgressAccess _progressAccess;

        
        public ProgressWatchers(IPersistentProgressAccess progressAccess)
        {
            _progressAccess = progressAccess;
        }
        
        /// <summary>
        /// Register game object components (readers and writers) recursively
        /// </summary>
        /// <param name="gameObject"></param>
        public void RegisterComponents(GameObject gameObject)
        {
            ISavedProgressReader[] progressReaders = gameObject.GetComponentsInChildren<ISavedProgressReader>();
            foreach (ISavedProgressReader progressReader in progressReaders)
            {
                Register(progressReader);
            }
        }

        public void InformReaders()
        {
            foreach (ISavedProgressReader progressReader in _readers)
                progressReader.LoadProgress(_progressAccess.PlayerProgress);
        }

        public void InformWriters()
        {
            foreach (ISavedProgressWriter progressWriter in _writers)
                progressWriter.UpdateProgress(_progressAccess.PlayerProgress);
        }

        public void CleanUp()
        {
            _readers.Clear();
            _writers.Clear();
        }

        private void Register(ISavedProgressReader progressReader)
        {
            _readers.Add(progressReader);
            
            if (progressReader is ISavedProgressWriter progressWriter)
                _writers.Add(progressWriter);
        }
    }
}