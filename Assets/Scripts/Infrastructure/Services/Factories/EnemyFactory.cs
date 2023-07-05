using GamePlay.Units;
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
        
        public GameObject Create(EnemyId enemyId, Vector3 position, Transform parent)
        {
            string prefabPath = _staticDataAccess.FindEnemyData(enemyId).PrefabPath;
            return _assetProvider.Instantiate<GameObject>(prefabPath, position, parent);
        }
    }
}