using GamePlay.Units.Loot;
using GamePlay.Units.Spawn;
using StaticData;

namespace Infrastructure.Services
{
    public interface IStaticDataAccess
    {
        public EnemyStaticData FindEnemyData(EnemyTypeId enemyTypeId);
        
        public LootStaticData FindLootData(LootTypeId lootTypeId);
    }
}