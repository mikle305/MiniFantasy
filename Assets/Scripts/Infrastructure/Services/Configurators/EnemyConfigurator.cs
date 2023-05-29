using Domain.Reaction;
using Domain.Units.Animations;
using Domain.Units.Health;
using Domain.Units.Spawn;
using Infrastructure.Services.StaticData;
using StaticData;
using UnityEngine;

namespace Infrastructure.Services.Configurators
{
    public class EnemyConfigurator : IEnemyConfigurator
    {
        private readonly IStaticDataAccess _staticDataAccess;

        public EnemyConfigurator(IStaticDataAccess staticDataAccess)
        {
            _staticDataAccess = staticDataAccess;
        }

        public void Configure(GameObject enemy, EnemyTypeId enemyTypeId)
        {
            EnemyStaticData enemyData = _staticDataAccess.FindEnemyData(enemyTypeId);
            InitHealth(enemy, enemyData);
            InitDeath(enemy, enemyData);
            InitHitting(enemy, enemyData);
            InitAggroZone(enemy, enemyData);
        }

        private static void InitHealth(GameObject enemy, EnemyStaticData enemyData)
        {
            if (enemy.TryGetComponent(out IHealth health))
                health.Init(enemyData.Health, enemyData.Health);
        }

        private static void InitDeath(GameObject enemy, EnemyStaticData enemyData)
        {
            if (enemy.TryGetComponent(out DeathOnDamage deathOnDamage))
                deathOnDamage.Init(enemyData.DeathDuration, enemyData.DestroyDuration, enemyData.DeathEffect);
        }

        private static void InitHitting(GameObject enemy, EnemyStaticData enemyData)
        {
            if (enemy.TryGetComponent(out HitOnDamage hitOnDamage))
                hitOnDamage.Init(enemyData.HitDuration, enemyData.HitEffect);
        }

        private static void InitAggroZone(GameObject enemy, EnemyStaticData enemyData)
        {
            if (enemy.TryGetComponent(out AggroZone aggroZone))
                aggroZone.Init(enemyData.FollowingCooldown);
        }
    }
}