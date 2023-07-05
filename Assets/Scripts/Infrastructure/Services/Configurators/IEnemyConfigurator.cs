using GamePlay.Units;
using UnityEngine;

namespace Infrastructure.Services
{
    public interface IEnemyConfigurator
    {
        public void Configure(GameObject enemy, EnemyId enemyId);
    }
}