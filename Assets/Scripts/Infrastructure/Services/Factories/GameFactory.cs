using Additional.Constants;
using GamePlay.Additional;
using GamePlay.Units;
using UI;
using UnityEngine;

namespace Infrastructure.Services
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

        public World CreateWorld()
        {
            var world = _assetProvider.Instantiate<World>(AssetPath.WorldPath);
            _progressWatchers.RegisterComponents(world.gameObject);
            return world;
        }

        public GameObject CreateCharacter(World world)
        {
            GameObject character = _assetProvider.Instantiate<GameObject>(
                AssetPath.CharacterPath, 
                world.SpawnPoint.position, 
                world.transform,
                injectInChildren: false);
            
            _progressWatchers.RegisterComponents(character);
            
            character
                .GetComponent<CharacterMovement>()
                .InitWorld(world.transform);

            return character;
        }

        public Hud CreateHud(GameObject character)
        {
            var hud = _assetProvider.Instantiate<Hud>(AssetPath.HudPath);

            var health = character.GetComponent<Health>();
            hud.HealthBar.Init(health);
            
            return hud;
        }
    }
}