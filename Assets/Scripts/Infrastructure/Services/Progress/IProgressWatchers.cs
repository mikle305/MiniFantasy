using UnityEngine;

namespace Infrastructure.Services
{
    public interface IProgressWatchers
    {
        public void RegisterComponents(GameObject gameObject, bool inChildren = false);

        public void RegisterComponents(Component component, bool inChildren = false);

        public void InformReaders();
        
        public void InformWriters();
        
        public void CleanUp();
    }
}