using System.Collections.Generic;
using System.Linq;
using Domain.Units.Spawn;
using StaticData;
using UnityEngine;

namespace Infrastructure.Services.StaticData
{
    public class StaticDataAccess : IStaticDataAccess
    {
        private Dictionary<EnemyTypeId, EnemyStaticData> _enemies;

        public void LoadEnemies() 
            => _enemies = Resources
                .LoadAll<EnemyStaticData>("StaticData/Enemies")
                .ToDictionary(e => e.EnemyTypeId, e => e);

        public EnemyStaticData FindEnemyData(EnemyTypeId enemyTypeId) 
            => _enemies.TryGetValue(enemyTypeId, out EnemyStaticData enemyStaticData) 
                ? enemyStaticData 
                : null;
    }
}