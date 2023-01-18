﻿using Additional;
using Character;
using Models;
using Services.AssetManagement;
using UnityEngine;

namespace Services.GameFactory
{
    public class GameFactory : IGameFactory
    {
        private readonly IAssetProvider _assetProvider;
        
        
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

            return character;
        }

        public World CreateWorld()
        {
            return _assetProvider.Instantiate<World>(AssetPath.WorldPath);
        }

        public void CreateHud()
        {
            _assetProvider.Instantiate(AssetPath.HudPath);
        }
    }
}