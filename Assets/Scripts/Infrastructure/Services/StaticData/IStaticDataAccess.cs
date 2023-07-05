using GamePlay;
using GamePlay.LootSystem;
using GamePlay.Units;
using StaticData;

namespace Infrastructure.Services
{
    public interface IStaticDataAccess
    {
        public EnemyStaticData FindEnemyData(EnemyId enemyId);
        
        public LootStaticData FindLootData(LootId lootId);
    }
}