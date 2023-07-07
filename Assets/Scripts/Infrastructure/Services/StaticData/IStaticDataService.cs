using GamePlay.LootSystem;
using GamePlay.Units;
using StaticData;

namespace Infrastructure.Services
{
    public interface IStaticDataService
    {
        public void LoadEnemies();

        public void LoadLoot();
        
        public EnemyStaticData FindEnemyData(EnemyId enemyId);
        
        public LootStaticData FindLootData(LootId lootId);
    }
}