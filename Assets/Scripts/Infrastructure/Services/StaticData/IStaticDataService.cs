using GamePlay.LootSystem;
using GamePlay.Units;
using StaticData;
using StaticData.Character;

namespace Infrastructure.Services
{
    public interface IStaticDataService
    {
        public void LoadEnemies();

        public void LoadLoot();

        public void LoadCharacter();
        
        public EnemyStaticData GetEnemyData(EnemyId enemyId);

        public LootStaticData GetLootData(LootId lootId);
        
        public CharacterStaticData GetCharacterData();
    }
}