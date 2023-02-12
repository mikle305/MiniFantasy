using UnityEngine;

namespace Infrastructure.Services.Progress
{
    public interface IProgressWatchers : IService
    {
        public void RegisterComponents(GameObject gameObject);

        public void InformReaders();
        
        public void InformWriters();
        
        public void CleanUp();
    }
}