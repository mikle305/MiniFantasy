using System;
using Additional.Utils;
using DiContainer.UniDependencyInjection.Core.Unity;
using Infrastructure.Services;
using UnityEngine;

namespace Domain.Units.Spawn
{
    public class EnemySpawner : MonoBehaviour
    {
        [SerializeField] private EnemyTypeId _enemyTypeId;

        private IEnemyFactory _enemyFactory;


        [Inject]
        public void Construct(IEnemyFactory enemyFactory)
        {
            _enemyFactory = enemyFactory;
        }

        public GameObject Spawn()
        {
            Func<Vector3, Transform, GameObject> factory = GetEnemyFactory(_enemyTypeId);
            return factory.Invoke(transform.position, transform);
        }

        private Func<Vector3, Transform, GameObject> GetEnemyFactory(EnemyTypeId enemyTypeId)
        {
            switch(enemyTypeId)
            {
                case EnemyTypeId.Ninja:
                    return _enemyFactory.CreateNinja;
                case EnemyTypeId.SkeletonArcher:
                    return _enemyFactory.CreateSkeletonArcher;
                default:
                    ThrowHelper.NotImplementedEnemyType(enemyTypeId);
                    return null;
            }
        }
    }
}