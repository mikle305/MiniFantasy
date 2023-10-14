using GamePlay.LootSystem;
using GamePlay.Reaction;
using GamePlay.Units;
using GamePlay.Units.Death;
using GamePlay.Units.Enemy;
using GamePlay.Units.Hit;
using StaticData;
using UnityEngine;

namespace Infrastructure.Services
{
    public class EnemyConfigurator : IEnemyConfigurator
    {
        private readonly IStaticDataService _staticDataService;

        public EnemyConfigurator(IStaticDataService staticDataService)
        {
            _staticDataService = staticDataService;
        }

        public void Configure(GameObject enemy, EnemyId enemyId)
        {
            EnemyData enemyData = _staticDataService.GetEnemyData(enemyId);
            InitHealth(enemy, enemyData);
            InitDeath(enemy, enemyData);
            InitHitting(enemy, enemyData);
            InitAggroZone(enemy, enemyData);
            InitLootSpawner(enemy, enemyData);
        }

        private static void InitHealth(GameObject enemy, EnemyData enemyData)
        {
            if (enemy.TryGetComponent(out Health health))
                health.Init(enemyData.Health, enemyData.Health);
        }

        private static void InitDeath(GameObject enemy, EnemyData enemyData)
        {
            if (enemy.TryGetComponent(out Death deathOnDamage))
                deathOnDamage.Init(enemyData.DeathDuration);
            
            if (enemy.TryGetComponent(out DestroyOnDeath destroyOnDeath))
                destroyOnDeath.Init(enemyData.DestroyDuration);
            
            if (enemy.TryGetComponent(out EffectOnDeath effectOnDeath))
                effectOnDeath.Init(enemyData.DeathEffect);
        }

        private static void InitHitting(GameObject enemy, EnemyData enemyData)
        {
            if (enemy.TryGetComponent(out HitOnDamage hitOnDamage))
                hitOnDamage.Init(enemyData.GetHitDuration);

            if (enemy.TryGetComponent(out EffectOnHit effectOnHit))
                effectOnHit.Init(enemyData.HitEffect);
        }

        private static void InitAggroZone(GameObject enemy, EnemyData enemyData)
        {
            if (enemy.TryGetComponent(out AggroZone aggroZone))
                aggroZone.Init(enemyData.FollowingCooldown);
        }

        private static void InitLootSpawner(GameObject enemy, EnemyData enemyData)
        {
            if (enemy.TryGetComponent(out LootSpawner lootSpawner))
                lootSpawner.Init(enemyData.LootCollection);
        }
    }
}