using System.Collections.Generic;
using Infrastructure.Services.PersistentProgress;
using Models;
using UnityEngine;

namespace Infrastructure.Services.Factory
{
    public interface IGameFactory : IService
    {
        public List<ISavedProgressReader> ProgressReaders { get; }
        
        public List<ISavedProgressWriter> ProgressWriters { get; }

        public GameObject CreateCharacter(World world);
        
        public World CreateWorld();
        
        public void CreateHud();

        public void CleanUp();
    }
}