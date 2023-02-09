using UnityEngine;

namespace Models
{
    public class World : MonoBehaviour
    {
        [SerializeField] private Transform _spawnPoint;
        [SerializeField] private NavMeshBaker _navMeshBaker;

        public Transform SpawnPoint => _spawnPoint;

        public NavMeshBaker NavMeshBaker => _navMeshBaker;
    }
}
