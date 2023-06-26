using GamePlay.NavMesh;
using GamePlay.Units.Spawn;
using UnityEngine;

namespace GamePlay.Views
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
