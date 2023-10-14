using GamePlay.Units.Enemy;
using UnityEngine;

namespace Infrastructure.Services
{
    public interface IEnemyFactory
    {
        public GameObject Create(EnemyId enemyId, Vector3 position, Transform parent);
    }
}