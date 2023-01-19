using System.Collections.Generic;
using Additional;
using Character;
using Infrastructure.Services.AssetManagement;
using Infrastructure.Services.PersistentProgress;
using Models;
using UnityEngine;

namespace Infrastructure.Services.Factory
{
    public class GameFactory : IGameFactory
    {
        private readonly IAssetProvider _assetProvider;
        
        public List<ISavedProgressReader> ProgressReaders { get; } = new();

        public List<ISavedProgressWriter> ProgressWriters { get; } = new();
        

        public GameFactory(IAssetProvider assetProvider)
        {
            _assetProvider = assetProvider;
        }

        public GameObject CreateCharacter(World world)
        {
            GameObject character = _assetProvider.Instantiate(AssetPath.CharacterPath, world.SpawnPoint.position, world.transform);
            character
                .GetComponent<CharacterMovement>()
                .InitWorld(world.transform);

            RegisterProgressWatchers(character);
            return character;
        }

        public World CreateWorld()
        { 
            var world = _assetProvider.Instantiate<World>(AssetPath.WorldPath);
            RegisterProgressWatchers(world.gameObject);
            return world;    
        }

        public void CreateHud()
        {
            _assetProvider.Instantiate(AssetPath.HudPath);
        }

        public void CleanUp()
        {
            ProgressWriters.Clear();
            ProgressReaders.Clear();
        }

        private void RegisterProgressWatchers(GameObject gameObject)
        {
            ISavedProgressReader[] progressReaders = gameObject.GetComponentsInChildren<ISavedProgressReader>();
            foreach (ISavedProgressReader progressReader in progressReaders)
            {
                RegisterProgressWatcher(progressReader);
            }
        }

        private void RegisterProgressWatcher(ISavedProgressReader progressReader)
        {
            ProgressReaders.Add(progressReader);
            
            if (progressReader is ISavedProgressWriter progressWriter)
                ProgressWriters.Add(progressWriter);
        }
    }
}