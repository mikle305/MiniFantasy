using Domain.Units.Spawn;
using UnityEngine;

namespace Infrastructure.Services
{
    public interface IEnemyFactory
    {
        GameObject Create(EnemyTypeId enemyTypeId, Vector3 position, Transform parent);
    }
}