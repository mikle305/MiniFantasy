using Additional.Constants;
using GamePlay.Additional;
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

        public FollowCamera CreateFollowCamera()
        {
            var followCamera = _assetProvider.Instantiate<FollowCamera>(AssetPath.FollowCamera);
            return followCamera;
        }

        public GameObject CreateCharacter(World world)
        {
            var character = _assetProvider.Instantiate<GameObject>(
                AssetPath.CharacterPath, 
                world.SpawnPoint.position, 
                world.transform,
                injectInChildren: false);
            
            _progressWatchers.RegisterComponents(character);

            return character;
        }
    }
}