using DiContainer.UniDependencyInjection.Core.Unity;
using Infrastructure.Services;
using UnityEngine;

namespace GamePlay.Units.Spawn
{
    public class EnemySpawner : MonoBehaviour
    {
        [SerializeField] private EnemyTypeId _enemyTypeId;

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
            GameObject enemy = _factory.Create(_enemyTypeId, transform.position, transform);
            _configurator.Configure(enemy, _enemyTypeId);
            return enemy;
        }
    }
}