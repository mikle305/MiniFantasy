using GamePlay.Units;
using UnityEngine;

namespace GamePlay.Additional
{
    public class World : MonoBehaviour
    {
        [SerializeField] private Transform _spawnPoint;
        [SerializeField] private Camera _uiCamera;

        public Transform SpawnPoint => _spawnPoint;
        public EnemySpawner[] EnemySpawners { get; private set; }
        public Camera UICamera => _uiCamera;


        private void Awake()
        {
            EnemySpawners = GetComponentsInChildren<EnemySpawner>();
        }
    }
}
