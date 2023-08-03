using GamePlay.LootSystem;
using UnityEngine;

namespace GamePlay.Units.Death
{
    public class SpawnLootOnDeath : MonoBehaviour
    {
        [SerializeField] private Death _death;
        [SerializeField] private LootSpawner _lootSpawner;

        private void Awake()
        {
            _death.Happened += _lootSpawner.Spawn;
        }
    }
}