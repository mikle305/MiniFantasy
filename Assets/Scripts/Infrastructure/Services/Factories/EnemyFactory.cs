using Additional.Constants;
using Domain.Units.Spawn;
using Infrastructure.Services.StaticData;
using UnityEngine;

namespace Infrastructure.Services
{
    public class EnemyFactory : IEnemyFactory
    {
        private readonly IAssetProvider _assetProvider;
        private readonly IStaticDataService _staticDataService;

        public EnemyFactory(IAssetProvider assetProvider, IStaticDataService staticDataService)
        {
            _assetProvider = assetProvider;
            _staticDataService = staticDataService;
        }
        
        public GameObject Create(EnemyTypeId enemyTypeId, Vector3 position, Transform parent) =>
            _assetProvider.Instantiate<GameObject>(_staticDataService.FindEnemyData(enemyTypeId).PrefabPath, position, parent);
    }
}