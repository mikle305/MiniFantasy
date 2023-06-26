using System.Collections.Generic;
using System.Linq;
using GamePlay.Units.Loot;
using GamePlay.Units.Spawn;
using StaticData;
using UnityEngine;

namespace Infrastructure.Services
{
    public class StaticDataService : IStaticDataAccess, IStaticDataLoader
    {
        private Dictionary<EnemyTypeId, EnemyStaticData> _enemiesMap;
        private Dictionary<LootTypeId, LootStaticData> _lootMap;

        public void LoadEnemies() 
            => _enemiesMap = Resources
                .LoadAll<EnemyStaticData>("StaticData/Enemies")
                .ToDictionary(e => e.EnemyTypeId, e => e);

        public void LoadLoot()
            => _lootMap = Resources
                .LoadAll<LootStaticData>("StaticData/Loot")
                .ToDictionary(l => l.LootTypeId, l => l);

        public EnemyStaticData FindEnemyData(EnemyTypeId enemyTypeId) 
            => _enemiesMap.TryGetValue(enemyTypeId, out EnemyStaticData enemyStaticData) 
                ? enemyStaticData 
                : null;

        public LootStaticData FindLootData(LootTypeId lootTypeId)
            => _lootMap.TryGetValue(lootTypeId, out LootStaticData lootStaticData)
                ? lootStaticData
                : null;
    }
}