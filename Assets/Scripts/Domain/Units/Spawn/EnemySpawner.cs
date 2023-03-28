using System;
using Additional.Utils;
using Infrastructure.Services;
using Infrastructure.Services.Factory;
using UnityEngine;

namespace Domain.Units.Spawn
{
    public class EnemySpawner : MonoBehaviour
    {
        [SerializeField] private EnemyTypeId _enemyTypeId;

        private IEnemyFactory _enemyFactory;

        
        private void Awake()
        {
            _enemyFactory = ServiceProvider.Container.Resolve<IEnemyFactory>();
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