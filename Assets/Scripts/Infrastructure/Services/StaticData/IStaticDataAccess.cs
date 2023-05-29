using Domain.Units.Spawn;
using StaticData;

namespace Infrastructure.Services.StaticData
{
    public interface IStaticDataAccess
    {
        public void LoadEnemies();
        
        public EnemyStaticData FindEnemyData(EnemyTypeId enemyTypeId);
    }
}