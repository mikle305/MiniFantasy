using System.Collections.Generic;
using System.Linq;
using Additional.Constants;
using GamePlay.LootSystem;
using GamePlay.Units;
using StaticData;
using UnityEngine;

namespace Infrastructure.Services
{
    public class StaticDataService : IStaticDataAccess, IStaticDataLoader
    {
        private Dictionary<EnemyId, EnemyStaticData> _enemiesMap;
        private Dictionary<LootId, LootStaticData> _lootMap;

        public void LoadEnemies() 
            => _enemiesMap = Resources
                .LoadAll<EnemyStaticData>(AssetPath.EnemiesFolder)
                .ToDictionary(e => e.Id, e => e);

        public void LoadLoot()
            => _lootMap = Resources
                .LoadAll<LootStaticData>(AssetPath.LootFolder)
                .ToDictionary(l => l.LootId, l => l);

        public EnemyStaticData FindEnemyData(EnemyId enemyId) 
            => _enemiesMap.TryGetValue(enemyId, out EnemyStaticData enemyStaticData) 
                ? enemyStaticData 
                : null;

        public LootStaticData FindLootData(LootId lootId)
            => _lootMap.TryGetValue(lootId, out LootStaticData lootStaticData)
                ? lootStaticData
                : null;
    }
}