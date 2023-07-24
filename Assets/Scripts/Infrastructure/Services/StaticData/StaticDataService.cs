using System.Collections.Generic;
using System.Linq;
using Additional.Constants;
using GamePlay.LootSystem;
using GamePlay.Units;
using StaticData;
using StaticData.Character;

namespace Infrastructure.Services
{
    public class StaticDataService : IStaticDataService
    {
        private Dictionary<EnemyId, EnemyStaticData> _enemiesMap;
        private Dictionary<LootId, LootStaticData> _lootMap;
        private CharacterStaticData _character;
        
        private readonly IAssetProvider _assetProvider;


        public StaticDataService(IAssetProvider assetProvider)
        {
            _assetProvider = assetProvider;
        }
        
        public void LoadEnemies() 
            => _enemiesMap = _assetProvider
                .LoadMany<EnemyStaticData>(AssetPath.EnemiesDataFolder)
                .ToDictionary(e => e.Id, e => e);

        public void LoadLoot()
            => _lootMap = _assetProvider
                .LoadMany<LootStaticData>(AssetPath.LootDataFolder)
                .ToDictionary(l => l.LootId, l => l);

        public void LoadCharacter()
            => _character = _assetProvider.Load<CharacterStaticData>(AssetPath.CharacterDataPath);

        public EnemyStaticData GetEnemyData(EnemyId enemyId) 
            => _enemiesMap.TryGetValue(enemyId, out EnemyStaticData enemyStaticData) 
                ? enemyStaticData 
                : null;

        public LootStaticData GetLootData(LootId lootId)
            => _lootMap.TryGetValue(lootId, out LootStaticData lootStaticData)
                ? lootStaticData
                : null;

        public CharacterStaticData GetCharacterData()
            => _character;
    }
}