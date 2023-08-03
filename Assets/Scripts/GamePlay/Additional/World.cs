using GamePlay.Units.Character;
using GamePlay.Units.Enemy;
using UnityEngine;

namespace GamePlay.Additional
{
    public class World : MonoBehaviour
    {
        [SerializeField] private CharacterSpawner _characterSpawner;
        [SerializeField] private Camera _uiCamera;

        public CharacterSpawner CharacterSpawner => _characterSpawner;
        public EnemySpawner[] EnemySpawners { get; private set; }
        public Camera UICamera => _uiCamera;


        private void Awake()
        {
            EnemySpawners = GetComponentsInChildren<EnemySpawner>();
        }
    }
}
