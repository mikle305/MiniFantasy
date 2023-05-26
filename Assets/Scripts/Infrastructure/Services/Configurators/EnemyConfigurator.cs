using Domain.Units.Spawn;
using Infrastructure.Services.StaticData;
using StaticData;
using UnityEngine;

namespace Infrastructure.Services.Configurators
{
    public class EnemyConfigurator : IEnemyConfigurator
    {
        private readonly IStaticDataService _staticDataService;

        public EnemyConfigurator(IStaticDataService staticDataService)
        {
            _staticDataService = staticDataService;
        }

        public void Configure(GameObject enemy, EnemyTypeId enemyTypeId)
        {
            EnemyStaticData enemyStaticData = _staticDataService.FindEnemyData(enemyTypeId);
        }
    }
}