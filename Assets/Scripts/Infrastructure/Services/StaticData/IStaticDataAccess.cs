using Domain.Units.Spawn;
using StaticData;

namespace Infrastructure.Services.StaticData
{
    public interface IStaticDataAccess
    {
        public EnemyStaticData FindEnemyData(EnemyTypeId enemyTypeId);
        
        public LootStaticData FindLootData(LootTypeId lootTypeId);
    }
}