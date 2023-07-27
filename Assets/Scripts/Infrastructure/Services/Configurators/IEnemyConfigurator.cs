using GamePlay.Units;
using GamePlay.Units.Enemy;
using UnityEngine;

namespace Infrastructure.Services
{
    public interface IEnemyConfigurator
    {
        public void Configure(GameObject enemy, EnemyId enemyId);
    }
}