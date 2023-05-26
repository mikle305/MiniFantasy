using Domain.Units.Spawn;
using StaticData;

namespace Infrastructure.Services.StaticData
{
    public interface IStaticDataService
    {
        public void LoadEnemies();
        
        public EnemyStaticData FindEnemyData(EnemyTypeId enemyTypeId);
    }
}