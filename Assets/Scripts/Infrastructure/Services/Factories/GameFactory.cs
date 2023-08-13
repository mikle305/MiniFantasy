using Additional.Constants;
using GamePlay.Additional;
using StaticData.Character;
using UnityEngine;

namespace Infrastructure.Services
{
    public class GameFactory : IGameFactory
    {
        private readonly IAssetProvider _assetProvider;
        private readonly IStaticDataService _staticDataService;


        public GameFactory(IAssetProvider assetProvider, IStaticDataService staticDataService)
        {
            _staticDataService = staticDataService;
            _assetProvider = assetProvider;
        }

        public World CreateWorld()
        {
            var world = _assetProvider.Instantiate<World>(AssetPath.WorldPath);
            return world;
        }

        public FollowCamera CreateFollowCamera()
        {
            var followCamera = _assetProvider.Instantiate<FollowCamera>(AssetPath.FollowCamera);
            return followCamera;
        }

        public GameObject CreateCharacter(Transform spawnPoint, Transform parent)
        {
            CharacterData data = _staticDataService.GetCharacterData();
            var character = _assetProvider
                .Instantiate<GameObject>(data.PrefabPath, spawnPoint.position, spawnPoint.rotation, parent);

            return character;
        }
    }
}