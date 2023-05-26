using Domain.NavMesh;
using Domain.Units.Spawn;
using UnityEngine;

namespace Domain.Views
{
    public class World : MonoBehaviour
    {
        [SerializeField] private Transform _spawnPoint;
        [SerializeField] private NavMeshBaker _navMeshBaker;
        
        public Transform SpawnPoint => _spawnPoint;
        public NavMeshBaker NavMeshBaker => _navMeshBaker;
        public EnemySpawner[] EnemySpawners { get; private set; }

        
        private void Awake()
        {
            EnemySpawners = GetComponentsInChildren<EnemySpawner>();
        }
    }
}
