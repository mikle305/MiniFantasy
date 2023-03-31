using UnityEngine;

namespace Infrastructure.Services
{
    public interface IProgressWatchers
    {
        public void RegisterComponents(GameObject gameObject);

        public void InformReaders();
        
        public void InformWriters();
        
        public void CleanUp();
    }
}