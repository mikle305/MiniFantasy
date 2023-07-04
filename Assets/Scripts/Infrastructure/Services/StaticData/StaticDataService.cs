using System.Collections.Generic;
using System.Linq;
using Additional.Constants;
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
                .LoadAll<EnemyStaticData>(AssetPath.EnemiesFolder)
                .ToDictionary(e => e.TypeId, e => e);

        public void LoadLoot()
            => _lootMap = Resources
                .LoadAll<LootStaticData>(AssetPath.LootFolder)
                .ToDictionary(l => l.TypeId, l => l);

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