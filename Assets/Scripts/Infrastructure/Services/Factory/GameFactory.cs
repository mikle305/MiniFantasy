﻿using Additional;
using Character;
using Infrastructure.Services.AssetManagement;
using Infrastructure.Services.ProgressWatchers;
using Models;
using UnityEngine;

namespace Infrastructure.Services.Factory
{
    public class GameFactory : IGameFactory
    {
        private readonly IAssetProvider _assetProvider;
        private readonly IProgressWatchers _progressWatchers;


        public GameFactory(IAssetProvider assetProvider, IProgressWatchers progressWatchers)
        {
            _assetProvider = assetProvider;
            _progressWatchers = progressWatchers;
        }

        public GameObject CreateCharacter(World world)
        {
            GameObject character = _assetProvider.Instantiate(AssetPath.CharacterPath, world.SpawnPoint.position, world.transform);
            character
                .GetComponent<CharacterMovement>()
                .InitWorld(world.transform);

            _progressWatchers.RegisterComponents(character);
            return character;
        }

        public World CreateWorld()
        { 
            var world = _assetProvider.Instantiate<World>(AssetPath.WorldPath);
            _progressWatchers.RegisterComponents(world.gameObject);
            return world;    
        }

        public void CreateHud()
        {
            _assetProvider.Instantiate(AssetPath.HudPath);
        }
    }
}