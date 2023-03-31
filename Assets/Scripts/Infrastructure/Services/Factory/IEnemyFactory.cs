using UnityEngine;

namespace Infrastructure.Services
{
    public interface IEnemyFactory
    {
        public GameObject CreateNinja(Vector3 position, Transform parent);
        
        public GameObject CreateSkeletonArcher(Vector3 position, Transform parent);
    }
}