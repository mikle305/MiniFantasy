using GamePlay.LootSystem;
using GamePlay.Units;
using GamePlay.Units.Enemy;
using StaticData;
using StaticData.Character;

namespace Infrastructure.Services
{
    public interface IStaticDataService
    {
        public void LoadEnemies();

        public void LoadLoot();

        public void LoadCharacter();
        
        public EnemyData GetEnemyData(EnemyId enemyId);

        public TData GetLootData<TData>(LootId lootId) 
            where TData : LootData;
        
        public CharacterData GetCharacterData();
        LootData GetLootData(LootId lootId);
    }
}