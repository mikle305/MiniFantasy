using Additional.Constants;
using DiContainer.UniDependencyInjection.Core.Unity;
using Domain.Units.Character;
using Domain.Units.Health;
using UnityEngine;
using Views;

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

        [MonoFactory(injectInChildren: true)]
        public World CreateWorld()
        {
            var world = _assetProvider.Instantiate<World>(AssetPath.WorldPath);
            _progressWatchers.RegisterComponents(world.gameObject);
            return world;
        }

        [MonoFactory]
        public GameObject CreateCharacter(World world)
        {
            GameObject character =
                _assetProvider.Instantiate(AssetPath.CharacterPath, world.SpawnPoint.position, world.transform);
            
            _progressWatchers.RegisterComponents(character);
            
            character
                .GetComponent<CharacterMovement>()
                .InitWorld(world.transform);

            return character;
        }

        [MonoFactory]
        public Hud CreateHud(GameObject character)
        {
            var hud = _assetProvider.Instantiate<Hud>(AssetPath.HudPath);

            var health = character.GetComponent<IHealth>();
            hud.HudActor.InitHealth(health, hud.HealthBar);
            
            return hud;
        }
    }
}