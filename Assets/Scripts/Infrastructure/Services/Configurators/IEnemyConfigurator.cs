using GamePlay.Units.Spawn;
using UnityEngine;

namespace Infrastructure.Services
{
    public interface IEnemyConfigurator
    {
        public void Configure(GameObject enemy, EnemyTypeId enemyTypeId);
    }
}