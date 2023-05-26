using Domain.Units.Spawn;
using UnityEngine;

namespace Infrastructure.Services.Configurators
{
    public interface IEnemyConfigurator
    {
        public void Configure(GameObject enemy, EnemyTypeId enemyTypeId);
    }
}