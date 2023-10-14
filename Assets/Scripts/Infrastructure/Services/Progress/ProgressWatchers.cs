using System.Collections.Generic;
using UnityEngine;

namespace Infrastructure.Services
{
    public class ProgressWatchers : IProgressWatchers
    {
        private readonly List<IProgressReader> _readers = new();
        private readonly List<IProgressWriter> _writers = new();
        private readonly IProgressAccess _progressAccess;

        
        public ProgressWatchers(IProgressAccess progressAccess)
        {
            _progressAccess = progressAccess;
        }
        
        /// <summary>
        /// Register game object components (readers and writers) recursively
        /// </summary>
        /// <param name="gameObject"></param>
        public void RegisterComponents(GameObject gameObject, bool inChildren = false)
        {
            IProgressReader[] progressReaders = inChildren 
                ? gameObject.GetComponentsInChildren<IProgressReader>(includeInactive: true)
                : gameObject.GetComponents<IProgressReader>();
            
            foreach (IProgressReader progressReader in progressReaders) 
                RegisterWatcher(progressReader);
        }
        
        public void RegisterComponents(Component component, bool inChildren = false)
        {
            IProgressReader[] progressReaders = inChildren 
                ? component.GetComponentsInChildren<IProgressReader>(includeInactive: true) 
                : component.GetComponents<IProgressReader>();
            
            foreach (IProgressReader progressReader in progressReaders) 
                RegisterWatcher(progressReader);
        }

        public void InformReaders()
        {
            foreach (IProgressReader progressReader in _readers)
                progressReader.ReadProgress(_progressAccess.Progress);
        }

        public void InformWriters()
        {
            foreach (IProgressWriter progressWriter in _writers)
                progressWriter.WriteProgress(_progressAccess.Progress);
        }

        public void CleanUp()
        {
            _readers.Clear();
            _writers.Clear();
        }

        private void RegisterWatcher(IProgressReader progressReader)
        {
            _readers.Add(progressReader);
            
            if (progressReader is IProgressWriter progressWriter)
                _writers.Add(progressWriter);
        }
    }
}