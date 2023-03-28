using Additional.Constants;
using Infrastructure.Services.AssetManagement;
using UnityEngine;

namespace Infrastructure.Services.Factory
{
    public class EnemyFactory : IEnemyFactory
    {
        private readonly IAssetProvider _assetProvider;

        public EnemyFactory(IAssetProvider assetProvider)
        {
            _assetProvider = assetProvider;
        }

        public GameObject CreateNinja(Vector3 position, Transform parent) =>
            _assetProvider.Instantiate(AssetPath.NinjaPath, position, parent);

        public GameObject CreateSkeletonArcher(Vector3 position, Transform parent) =>
            _assetProvider.Instantiate(AssetPath.SkeletonArcherPath, position, parent);
    }
}