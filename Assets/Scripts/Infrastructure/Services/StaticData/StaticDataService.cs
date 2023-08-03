using System.Collections.Generic;
using System.Linq;
using Additional.Constants;
using Additional.Utils;
using GamePlay.LootSystem;
using GamePlay.Units.Enemy;
using StaticData;
using StaticData.Character;

namespace Infrastructure.Services
{
    public class StaticDataService : IStaticDataService
    {
        private Dictionary<EnemyId, EnemyData> _enemiesMap;
        private Dictionary<LootId, LootData> _lootMap;
        private CharacterData _character;
        private HudConfiguration _hudConfig;

        private readonly IAssetProvider _assetProvider;


        public StaticDataService(IAssetProvider assetProvider)
        {
            _assetProvider = assetProvider;
        }
        
        public void LoadEnemies() 
            => _enemiesMap = _assetProvider
                .LoadMany<EnemyData>(AssetPath.EnemiesDataFolder)
                .ToDictionary(e => e.Id, e => e);

        public void LoadLoot()
            => _lootMap = _assetProvider
                .LoadMany<LootData>(AssetPath.LootDataFolder)
                .ToDictionary(l => l.LootId, l => l);

        public void LoadCharacter()
            => _character = _assetProvider.Load<CharacterData>(AssetPath.CharacterDataPath);

        public void LoadUiConfigs()
        {
            _hudConfig = _assetProvider.Load<HudConfiguration>(AssetPath.HudConfigPath);
        }

        public EnemyData GetEnemyData(EnemyId enemyId)
        {
            if (!_enemiesMap.TryGetValue(enemyId, out EnemyData enemyData))
                ThrowHelper.SoNotExists();

            return enemyData;
        }

        public LootData GetLootData(LootId lootId)
        {
            if (!_lootMap.TryGetValue(lootId, out LootData lootData))
                ThrowHelper.SoNotExists();

            return lootData;
        }

        public TData GetLootData<TData>(LootId lootId) 
            where TData : LootData
        {
            LootData lootData = GetLootData(lootId);
            if (lootData is not TData)
                ThrowHelper.InvalidLootType<TData>();

            return lootData as TData;
        }

        public CharacterData GetCharacterData()
        {
            if (_character == null)
                ThrowHelper.SoNotExists();

            return _character;
        }

        public HudConfiguration GetHudConfig()
            => _hudConfig;
    }
}