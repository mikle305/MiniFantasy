using UnityEngine;

namespace Infrastructure.Services
{
    public interface IProgressWatchers
    {
        public void RegisterComponents(GameObject gameObject);

        public void RegisterComponents(Component component);

        public void InformReaders();
        
        public void InformWriters();
        
        public void CleanUp();
    }
}