using Infrastructure.Services;
using UniDependencyInjection.Unity;
using UnityEngine;

namespace GamePlay.Units.Enemy
{
    public class EnemySpawner : MonoBehaviour
    {
        [SerializeField] private EnemyId _enemyId = EnemyId.None;

        private IEnemyFactory _factory;
        private IEnemyConfigurator _configurator;


        [Inject]
        public void Construct(IEnemyFactory factory, IEnemyConfigurator configurator)
        {
            _factory = factory;
            _configurator = configurator;
        }

        public GameObject Spawn()
        {
            GameObject enemy = _factory.Create(_enemyId, transform.position, transform);
            _configurator.Configure(enemy, _enemyId);
            return enemy;
        }
    }
}