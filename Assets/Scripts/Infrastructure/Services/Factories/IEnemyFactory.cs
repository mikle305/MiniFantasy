using GamePlay.Units.Spawn;
using UnityEngine;

namespace Infrastructure.Services
{
    public interface IEnemyFactory
    {
        public GameObject Create(EnemyTypeId enemyTypeId, Vector3 position, Transform parent);
    }
}