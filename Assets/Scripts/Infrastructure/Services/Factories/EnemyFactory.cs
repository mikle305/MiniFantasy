using Domain.Units.Spawn;
using Infrastructure.Services.StaticData;
using UnityEngine;

namespace Infrastructure.Services
{
    public class EnemyFactory : IEnemyFactory
    {
        private readonly IAssetProvider _assetProvider;
        private readonly IStaticDataAccess _staticDataAccess;

        public EnemyFactory(IAssetProvider assetProvider, IStaticDataAccess staticDataAccess)
        {
            _assetProvider = assetProvider;
            _staticDataAccess = staticDataAccess;
        }
        
        public GameObject Create(EnemyTypeId enemyTypeId, Vector3 position, Transform parent)
        {
            string prefabPath = _staticDataAccess.FindEnemyData(enemyTypeId).PrefabPath;
            return _assetProvider.Instantiate<GameObject>(prefabPath, position, parent);
        }
    }
}