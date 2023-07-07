using GamePlay.Units;
using UnityEngine;

namespace GamePlay.Additional
{
    public class World : MonoBehaviour
    {
        [SerializeField] private Camera _uiCamera;
        [SerializeField] private Transform _spawnPoint;
        [SerializeField] private NavMeshBaker _navMeshBaker;

        public Camera UICamera => _uiCamera;
        public Transform SpawnPoint => _spawnPoint;
        public NavMeshBaker NavMeshBaker => _navMeshBaker;
        public EnemySpawner[] EnemySpawners { get; private set; }


        private void Awake()
        {
            EnemySpawners = GetComponentsInChildren<EnemySpawner>();
        }
    }
}
