using System.Collections.Generic;
using System.Linq;
using Additional.Constants;
using GamePlay.LootSystem;
using GamePlay.Units;
using StaticData;

namespace Infrastructure.Services
{
    public class StaticDataService : IStaticDataService
    {
        private Dictionary<EnemyId, EnemyStaticData> _enemiesMap;
        private Dictionary<LootId, LootStaticData> _lootMap;
        private readonly IAssetProvider _assetProvider;


        public StaticDataService(IAssetProvider assetProvider)
        {
            _assetProvider = assetProvider;
        }
        
        public void LoadEnemies() 
            => _enemiesMap = _assetProvider
                .LoadMany<EnemyStaticData>(AssetPath.EnemiesFolder)
                .ToDictionary(e => e.Id, e => e);

        public void LoadLoot()
            => _lootMap = _assetProvider
                .LoadMany<LootStaticData>(AssetPath.LootFolder)
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